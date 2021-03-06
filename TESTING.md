WHO:

                             Tyler Albee - tyleralbee

                             Kyle Giacomini - suveck
                             
                             Anna Shea - annashea
                             
                             Cody Mattern - CodyMattern

VISION: Our goal is to make catching up with your friends and local community as easy as possible. By allowing users to take advantage of geolocator based notifications and events users can easily organize for meet ups or put notes/pictures/videos for others at any location.

TITILE: Pinned!

AUTOMATED TESTS:
Steps:
 1) Click button [![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/e781ef7ab7b6dce8b619)
 2) Click Open with "Chrome" or "Windows"
 3) After sucesfull importation of the collection "Pinned"
 4) Mouse over the collection on your left hand side. Click the arrow pointing right
 5) Click Run then Start Run
 
 Results:
 
![alt text][results]

[results]: http://i.imgur.com/xUPuU2B.png "Resuts"



USER ACCEPTANCE TESTS:

1. Create user information via eMail

Description

    Code is sent to user eMail, user is prompted for said code, and upon entry a user account is created.

Pre-conditions

    User has valid email (email both exists and is not in use)

Test steps

    1. User clicks [Need an Account?]

    2. Code is sent to valid email

       b. Email is recognized as not valid

    3. User enters received code to Pinned!

    4. User clicks [Create Account!]

Expected result

    User should have created him or herself a new account

Actual result

    User is navigated to their home map and is prompted for further permissions (contacts, etc).

Status (Pass/Fail)

    Pass

Notes

    Upon account creation, the user is taken to their home page and is given a quick debrief on the workings of the app.

Post-conditions

    New user information is validated with database and the user is successfully signed into their account. The account session details are logged in database.

2. Create user information via Facebook

Description

    User creates an account using Facebook to better connect with friends and login without need for email verification.

Pre-conditions

    User has valid Facebook (Facebook both exists and is not in use)

Test steps

    1. User clicks [Login with Facebook]

    2. User accepts permissions in Facebook app

    3. User clicks [Create Account!]

Expected result

    User should have created him or herself a new account

Actual result

    User is navigated to their home map and is prompted for further permissions (contacts, Facebook friends they&#39;d like to be friends with, etc).

Status (Pass/Fail)

    Pass

Notes

    Upon creating an account through Facebook, the user will be prompted within the app to choose his or her friends on Pinned! from his or her Facebook friends list.

Post-conditions

    New user information is validated with database and the user is successfully signed into their account. The account session details are logged in database, Facebook information is stored so that the user will never have to connect to Facebook twice.

3. Verify login with valid user name and password through email or Facebook.
    
Description

    These steps test the login page functions.
    
Pre-conditions

    User must have a valid user name and password created in the app to be able to login with email or password.
    
Test steps

    1. Open the app on the device
    2. Provide a valid user name used to login, such as email or Facebook username.
    3. Provide a valid password used to login into an email or Facebook account.
    4. Click the login button.
    
Expected result

    The user should be able to login in their account.
    
Actual result

    User is navigated to next page with successful login.
    
Status (Pass/Fail)

    Pass
    
Notes

    If incorrect username or password is entered, an error message will appear.
    
Post-conditions

    User is validated with database and successfully signed into their account.
    The account session details are logged in database.
