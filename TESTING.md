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

3. Verify login with valid user name and password

Description

    Test the Google login page

Pre-conditions

    User has valid user name and password

Test steps

    1. Navigate to login page

    2. Provide valid user name

    3. Provide valid password

    4. Click login button

Expected result

    User should be able to login

Actual result

    User is navigated to dashboard with successful login

Status (Pass/Fail)

    Pass

Notes

    N/A

Post-conditions

    User is validated with database and successfully signed into their account.

    The account session details are logged in database.
