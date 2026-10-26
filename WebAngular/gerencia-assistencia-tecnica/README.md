# GerenciaAssistenciaTecnica

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 7.3.9.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Automated deployment

The `Deploy frontend` GitHub Actions workflow builds the production frontend and publishes it to IIS with WebDeploy when changes are pushed to `main`. It can also be started manually from the Actions tab with **Run workflow**.

Before running it, add these repository Actions secrets under **Settings > Secrets and variables > Actions**:

- `WEBDEPLOY_URL`: the WebDeploy service URL, including its `site` query parameter.
- `WEBDEPLOY_SITE`: the IIS site/application name.
- `WEBDEPLOY_USERNAME`: the WebDeploy username.
- `WEBDEPLOY_PASSWORD`: the WebDeploy password.

The workflow uses the `msdeploy.exe` installed on the Windows runner and deploys the Angular `browser` output along with `src/web.config` for client-side routing. No deployment credentials are stored in the repository.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
