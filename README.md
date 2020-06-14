# NUnit Documentation

This repository serves the content that is found at <http://docs.nunit.org>.

## How to Build these docs locally

* Prerequisite: Install [docfx](https://dotnet.github.io/docfx/) (using [Chocolatey](https://chocolatey.org/)? The command is `choco install docfx -y`)
* Pull this repository
* `cd docs`
* Run `docfx build`
* Run `docfx serve` and navigate to <http://localhost:8080/_site>

We'd love your contributions! See [The contributing guide](CONTRIBUTING.md) for how to get involved.

## How the Docs are Built and Deployed

* We build the docs via the GitHub actions located in `./github/workflows`.
* The workflow uses a container with docfx installed; the container builds the docs.
* The workflow then uses another container to push the results to the `gh-pages` branch, using a personal access token that is stored in the repository's settings. 
* GitHub serves the outputted site from the `gh-pages` branch, and the DNS of `docs.nunit.org` points there.