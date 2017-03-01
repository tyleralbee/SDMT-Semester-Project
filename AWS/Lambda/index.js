//Global Variables
var AWS = require('aws-sdk');
AWS.config.region = 'us-west-2';

function userSignup(event, context) 
{
    var cognitoidentityserviceprovider = new AWS.CognitoIdentityServiceProvider();
    cognitoidentityserviceprovider.signUp(event, function(err, data) {
    if (err) {
        console.log(err, err.stack);
        context.fail(err);
    } else {
        console.log(data);
        context.succeed(data);
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
        context.succeed(data);
    }
    });
}



exports.handler = (event, context, callback) => {
    
    var result;
    
    switch(event.operation) {
    case 'userSignup':
        userSignup(event.payload, context)
        break;
    case 'userConfirm':
        userConfirmSignup(event.payload, context)
        break;
    case 'userLogin':
        userLogin(event.payload, context)
        break;
    default:
        callback(null, "Invalid Operation")
    } 
};