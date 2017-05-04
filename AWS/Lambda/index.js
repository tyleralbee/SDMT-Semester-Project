//Global Variables
var AWS = require('aws-sdk');
AWS.config.region = 'us-west-2';
var mysql = require('mysql');

function userSignup(event, context, connection) 
{
    var cognitoidentityserviceprovider = new AWS.CognitoIdentityServiceProvider();
    cognitoidentityserviceprovider.signUp(event, function(err, data) {
    if (err) {
        console.log(err, err.stack);
        context.fail(err);
    } else {
        console.log(data);
        context.succeed(data);
        
        var userAtt = event.UserAttributes;
        var given_name = ''
        var family_name = ''
        for(var key in userAtt) {
            //console.log("Key " + userAtt[key].Name );
            if(userAtt[key].Name == 'given_name') {
                given_name = userAtt[key].Value
            } else if (userAtt[key].Name == 'family_name') {
                family_name = userAtt[key].Value
            }
        }
        
        var sql = "INSERT INTO tbl_Members (firstName, lastName, username) VALUES ('"+ given_name +"', '"+family_name+"', '"+ event.Username +"');";
        console.log(sql);
        connection.query(sql, function (err, results, fields) {
            if (err) {
                console.error('error connecting: ' + err.stack);
                context.fail(err);
            } else {
            context.succeed(results);  
            }
        });
        connection.end();
        
    }
    });
}

function userConfirmSignup(event, context) {
    var cognitoUser = new AWS.CognitoIdentityServiceProvider();
    cognitoUser.confirmSignUp(event, function(err, data) {
    if (err) {
        console.log(err, err.stack); // an error occurred  
        context.fail(err);
    } else {
        console.log(data);           // successful response
        context.succeed(data, "success");
    }
    });
}

function userLogin(event, context) {
    var cognitoUser = new AWS.CognitoIdentityServiceProvider();
    cognitoUser.adminInitiateAuth(event, function(err, data) {
    if (err) {
        console.log(err, err.stack); // an error occurred  
        context.fail(err);
    } else {
        console.log(data);           // successful response
        context.succeed(data.AuthenticationResult);
    }
    });
}

function addFriend(event, context, connection) {
    
    var sql = "INSERT INTO tbl_Friends VALUES ('" + event.userID1 + "', '" + event.userID2 + "');";
    console.log(sql);
    connection.query(sql, function (err, results, fields) {
        if (err) {
            console.error('error connecting: ' + err.stack);
            context.fail(err);
        } else {
            context.succeed(results);  
        }
    });
    connection.end();
}
function getPinList(event, connection, context) {
    var sql = "SELECT * FROM tbl_Pins WHERE userID='" + event.memberID + "';";
    console.log(sql);
    connection.query(sql, function (err, results, fields) {
        if (err) {
            console.error('error connecting: ' + err.stack);
            context.fail(err);
        } else {
            context.succeed(results);  
        }
    });
    connection.end();
}

function createPin(event, connection, context) {
    var sql = "INSERT INTO tbl_Pins (userID, title, description, longitude, latitude) VALUES ('" + event.memberID + "', '" + event.title + "', '" + event.desc + "', '" + event.longitude + "', '" + event.latitude + "');";
    console.log(sql);
    connection.query(sql, function (err, results, fields) {
        if (err) {
            console.error('error connecting: ' + err.stack);
            context.fail(err);
        } else {
            context.succeed(results);  
        }
    });
    connection.end();
}

exports.handler = (event, context, callback) => {
    
    var connection = mysql.createConnection({
      host     : 'pinneddb.ccm6yrcnsjsu.us-west-2.rds.amazonaws.com',
      port     : '3306',
      user     : 'pinned',
      password : 'password1',
      database : 'PinnedDB'
    });
    connection.connect(function(err) {
    if ( !err ) {
        console.log("Connected to MySQL");
    } else {
        console.log(err);
    }
    });
    switch(event.operation) {
    case 'userSignup':
        userSignup(event.payload, context, connection)
        break;
    case 'userConfirm':
        userConfirmSignup(event.payload, context)
        break;
    case 'userLogin':
        userLogin(event.payload, context)
        break;
    case 'addFriend':
        addFriend(event.payload, context, connection)
        break;
    case 'getPins':
        getPinList(event.payload, connection, context)
        break;
    case 'createPin':
        createPin(event.payload, connection, context)
        break;
    default:
        callback(null, "Invalid Operation")
    } 
};