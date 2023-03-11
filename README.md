# NUnit Documentation

This repository serves the content that is found at <https://docs.nunit.org>.

[![NUnit Documentation Build Process](https://github.com/nunit/docs/actions/workflows/build-process.yml/badge.svg)](https://github.com/nunit/docs/actions/workflows/build-process.yml)

## What is the Docs site? How does it work?

The docs site is a project within the NUnit organization. [Read the vision at VISION.md](VISION.md) to understand more about how the documentation fits into the overall organization and how it supports the other projects.

## How to Build these docs locally

* Prerequisite: Install [docfx](https://dotnet.github.io/docfx/) (using [Chocolatey](https://chocolatey.org/)? The command is `choco install docfx -y`)
* Pull this repository
* `cd docs`
* Run `docfx build`
* Run `docfx serve` and navigate to <http://localhost:8080/_site>

## How to Build These Docs Within GitHub Codespaces or a Dev Container

Fancy using GitHub Codespaces for your work on these docs? Or want to work in the environment locally? You can!

* Open the branch you want to work on in GitHub Codespaces
* The tooling, VS code extensions, etc. that we use will immediately be available to you.
* To build from the Codespaces terminal: `build` (we've taken care of the rest for you)
* To serve / preview from the Codespaces terminal: `serve` (we've taken care of the rest for you)
* To run markdown linting from the Codespaces terminal: `lint` (we've taken care of the rest for you)
* To run spellcheck from the Codespaces terminal: `spellcheck` (we've taken care of the rest for you)
* To build/test the snippets from the Codespaces terminal: `snippets` (we've taken care of the rest for you)

We'll be working on follow-ups to make this more user-friendly, but it's now workable.

## Linting Locally

* Install `markdownlint-cli2`: `npm install markdownlint-cli2 -g`
* Open the root of the project (`/`, not `/docs`)
* Run `markdownlint-cli2-config ".github/linters/.markdownlint.yml" "docs/**/*.md"`

We'd love your contributions! See [The contributing guide](CONTRIBUTING.md) for how to get involved.

## How the Docs are Built and Deployed

* We build the docs via the GitHub actions located in `./github/workflows`.
* The workflow uses a container with docfx installed; the container builds the docs.
* The workflow then uses another container to push the results to the `gh-pages` branch, using a personal access token that is stored in the repository's settings.
* GitHub serves the outputted site from the `gh-pages` branch, and the DNS of `docs.nunit.org` points there.
