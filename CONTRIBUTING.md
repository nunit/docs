# Contributing to the NUnit Documentation

We're glad you're interested in helping with the NUnit documentation! This guide is a brief intro to the project and some suggestions.

Rule number 1: When in doubt, reach out! There's no harm in opening an issue to have a discussion.

## How to Submit an Issue

Please submit a docs issue on our GitHub issues page at <https://github.com/nunit/docs/issues/new>.

We'll do our best to work with you and help you, whatever the issue is. For the best possible results:

* Try to make your issue as specific as possible
* Tell us what your expectation was of what *should* happen, as well as what *actually* happened. Lots of issues can be resolved by understanding someone's expectations.

## Have an Idea / Request for Improvement?

That's great! We love to hear feedback on how we can improve things.

Please know, however, that we may not be able to immediately implement your ideas or suggestions. OSS work is sometimes limited by time and other constraints.

We suggest [submitting an issue](https://github.com/nunit/docs/issues/new) with the idea or improvement so that we can discuss it first. At that point, assuming we agree it's a good fit, we will attempt to implement it, or guide you to help you do so within your own pull request(s).

## Contributing Code via a Pull Request

So you've got some docs you'd like to contribute to the project. First off -- **Thank you**! It means a lot to us that you'd take your time to help improve this project.

We try to avoid being strict about accepting PRs because we value contributions from others, but some general guidelines are below. If you are unsure about any of the steps to contribute, just ask -- we're happy to help.

## General Suggestions

* You should probably [submit an issue](https://github.com/nunit/docs/issues/new) before beginning a pull request. This makes sure that we have a good heads up that you want to contribute, and also makes sure that if we don't think the idea is a good fit, you don't spend time writing docs only to have the PR rejected later.
* We suggest creating a pull request early in the process and placing `WIP` or `In Progress` in the title of the pull request (you can edit it later). This way, as you add changes, we can see the progress, and might be able to jump in to help if we see things going off the rails. This one's your call, though; do whatever suits you.
* Try to make many small commits, with notes, at each step of the way. This will help us understand your thought process when we review the PR. We'll squash these changes at the end of the process, so no worries about being verbose throughout.
* Similarly, don't worry about pre-squashing your changes for us. We'll use Github's functionality at the end of the PR to do that when accepting it.
* Before asking for a review or declaring the PR to be ready, make sure the CI build passes. You'll receive updates on this as you go, so the status at any given time should hopefully be clear.

## How to Contribute

There are a few ways to contribute. Here's a video showing them, as of January 2023:

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/VSJwystllJM/0.jpg)](https://www.youtube.com/watch?v=VSJwystllJM)

### Option 1: Using GitHub In-line Editing

* From the NUnit docs site, you can click `Improve This Document` to take you to the markdown file for the page you're viewing.
* From there, you can click the edit icon to edit the text.
* Once you've made your changes, you can click `Commit These Changes` which will guide you through creating a branch and pull request to submit the change to us.

Once the PR is submitted, our build will run. If there are any spellcheck issues or markdown linting issues, you'll receive an e-mail with the failures. No worries -- we'll help you out.

### Option 2: Fork & Commit as Typical

If you're familiar with OSS and GitHub, you can fork the repository, check it out, make a branch, and submit any changes. Our build process will pick up if there are spelling or markdown issues and we can work together to address them in the PR.

### Option 3: A Richer Experience with GitHub Codespaces

You can open the repository in GitHub Codespaces. This will open an instance of VS Code, in a browser window, with all of the extensions we use installed. You'll get:

* Syntax highlighting for spelling and markdown issues
* Auto-formatting on save according to our standards
* Simple command aliases in the terminal to cover most folks' workflows:
  * `spellcheck`: Check for spelling errors in docs
  * `lint`: Markdown linting
  * `build`: Use docfx to build site
  * `serve`: Build with docfx but also serve the generated site
  * `apidocs`: If needed, downloads the latest NUnit release to extract it to the right place so that the API documentation can generate. (This happens automatically upon startup)
  * `snippets`: Builds the snippets projects to ensure they work.

### Option 3a: A Container Within VS Code

You can check out the codebase on your local machine and open it with VSCode. If you have Docker installed, VS Code will prompt you to reopen within a container. It will build the same container that Codespaces above uses, and you'll have the same functionality available to you.

## Is this confusing? Do you need help? Do you feel hesitant?

That's a common feeling, especially if you're new to open source or making contributions. If you haven't heard a term like "pull request" before, don't worry -- we've got you covered. Let us know if you'd like to take a pass at making a change, and we'll help you along the way.

## How to build this Project

See the documentation in the [README.md](README.md) file.
