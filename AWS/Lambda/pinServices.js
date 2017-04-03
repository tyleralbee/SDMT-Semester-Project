//Global Variables
var AWS = require('aws-sdk');
AWS.config.region = 'us-west-2';
var mysql = require('mysql');

function getPinList(event, connection, context) {
    connection.query('SELECT * FROM `tbl_Pins`', function (err, results, fields) {
    if (err) {
    console.error('error connecting: ' + err.stack);
    context.fail(err);
    } else {
    context.succeed(results);  
    }});
}




exports.handler = (event, context, callback) => {
    var connection = mysql.createConnection({
      host     : 'pinneddb.ccm6yrcnsjsu.us-west-2.rds.amazonaws.com:3306',
      user     : 'pinned',
      password : 'password1',
      database : 'pinnedDB'
    });

    switch(event.operation) {
        case 'getPins':
            getPinList(event.payload, connection, context)
            break;
        case 'createPin':
            break;
        case 'updatePin':
            break;
        default:
            callback(null, "Invalid Operation")
    } 
};
