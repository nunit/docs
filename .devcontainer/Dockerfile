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
# We get the first workspace, because there should only be one
# This is so that when someone updates their devcontainer name, it doesn't get screwed up
RUN $first_workspace="$(cd /workspaces && ls | head -1)"
RUN alias gotoworkspace="cd /workspaces/$first_workspace"

RUN echo 'alias spellcheck="cspell --config /workspaces/$first_workspace/cSpell.json \"/workspaces/$first_workspace/docs/**/*.md\" --no-progress"' >> ~/.bashrc
RUN echo 'alias lint="markdownlint -c /workspaces/$first_workspace/.github/linters/.markdown-lint.yml /workspaces/$first_workspace/docs/**/*.md"' >> ~/.bashrc
RUN echo 'alias build="cd /workspaces/$first_workspace/docs && docfx build"' >> ~/.bashrc
RUN echo 'alias serve="build && docfx serve _site -n \"*\""' >> ~/.bashrc
