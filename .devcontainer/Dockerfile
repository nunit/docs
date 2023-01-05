FROM ghcr.io/nunit/docfx-action:v2.0.0-preview.3
EXPOSE 8080

### Installing Node LTS into the container
RUN curl -fsSL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install nodejs

RUN npm install -g yarn
RUN npm install -g npm
RUN npm install -g cspell
RUN npm install -g markdownlint-cli

RUN node -v
RUN npm -v
RUN yarn -v
### Add the aliases

RUN echo 'alias spellcheck="cspell --config /workspaces/nunit-docs/cSpell.json \"/workspaces/nunit-docs/docs/**/*.md\" --no-progress"' >> ~/.bashrc
RUN echo 'alias lint="markdownlint -c /workspaces/nunit-docs/.github/linters/.markdown-lint.yml /workspaces/nunit-docs/docs/**/*.md"' >> ~/.bashrc
RUN echo 'alias build="cd /workspaces/nunit-docs/docs && docfx build"' >> ~/.bashrc
RUN echo 'alias serve="build && docfx serve _site -n \"*\""' >> ~/.bashrc
