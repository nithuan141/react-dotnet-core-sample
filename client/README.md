This is the front end project which is bootstrapped with [Create React App](https://github.com/facebookincubator/create-react-app).

Clone this repository and run the below command from the project folder to install the dependencies

## `npm install`

Replace the value of BASE_URL in config.js with the url of the hosted web API (server) (localhost/IIS)

  var config = {
      BASE_URL : 'http://localhost:4030/api'
  }

## `Build and Run`

In the project directory, you can run :

### `npm start`

Runs the app in the development mode.<br>
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.<br>
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.<br>
See the section about [running tests](#running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.<br>
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.<br>
Your app is ready to be deployed!
