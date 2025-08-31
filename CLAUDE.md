# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

This is the NUnit documentation repository that serves content at <https://docs.nunit.org>. It's a DocFX-based static site generator that builds documentation from markdown files and generates API documentation from .NET assemblies.

## Architecture

- **docs/**: Main documentation content including articles, markdown files, and DocFX configuration
- **docs/docfx.json**: Primary DocFX configuration file that defines build settings, metadata, and site structure
- **docs/snippets/**: .NET solution (Snippets.sln) containing C# code snippets used in documentation
- **code-output/**: Directory where NUnit release assemblies are placed for API documentation generation
- **legacy/**: Legacy documentation content served as static resources
- **.devcontainer/**: Docker-based development environment with pre-configured tools

## Development Commands

### DevContainer/Codespaces (Recommended)

- `build` - Build the documentation site using DocFX
- `serve` - Build and serve the site locally at <http://localhost:8080>
- `lint` - Run markdown linting using markdownlint-cli2
- `spellcheck` - Run spell checking using cspell
- `snippets` - Build and test the code snippets solution
- `apidocs` - Download latest NUnit API documentation

### Local Development (requires docfx installed)

- `docfx docs/docfx.json` - Build the site
- `docfx docs/docfx.json --serve` - Build and serve locally
- `markdownlint-cli2 --config ".github/linters/.markdownlint.yml" "docs/**/*.md"` - Lint markdown
- `cspell --config cSpell.json "docs/**/*.md" --no-progress` - Spell check
- `dotnet test docs/snippets/Snippets.sln` - Test code snippets

## Key Configuration Files

- **docs/docfx.json**: DocFX build configuration, metadata generation, and site settings
- **cSpell.json**: Spell checker dictionary and configuration
- **.github/linters/.markdownlint.yml**: Markdown linting rules
- **.markdownlintrc**: Additional markdown lint configuration
- **docs/filterConfig.yml**: API documentation filtering rules

## Documentation Structure

- **docs/articles/**: Main documentation content organized by topic
- **docs/api/**: Generated API documentation (auto-generated from code-output assemblies)
- **docs/legacy/**: Legacy documentation served as static files
- **docs/images/**, **docs/css/**, **docs/js/**: Static assets
- **docs/toc.yml**: Main table of contents structure

## Code Snippets

The repository includes a .NET solution at `docs/snippets/Snippets.sln` containing:

- **Snippets.NUnit**: NUnit framework code examples
- **Snippets.NUnitLite**: NUnit Lite framework examples

Code snippets are tested as part of the build process to ensure documentation examples remain valid.

## API Documentation Generation

API docs are generated from NUnit release assemblies placed in the `code-output/` directory. The DevContainer automatically downloads the latest release, or assemblies can be manually extracted from NUnit GitHub releases.

## Deployment

The site is built and deployed via GitHub Actions to the `gh-pages` branch, which serves <https://docs.nunit.org>.
