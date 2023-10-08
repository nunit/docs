FROM ghcr.io/nunit/docfx-action:v2.10.0
EXPOSE 8080

### Installing Node LTS into the container
RUN curl -fsSL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install nodejs

RUN npm install -g yarn
RUN npm install -g npm
RUN npm install -g cspell
RUN npm install -g markdownlint-cli2

RUN node -v
RUN npm -v
RUN yarn -v

### Add the aliases
# We get the first workspace, because there should only be one
# This is so that when someone updates their devcontainer name, it doesn't get screwed up
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias spellcheck="cspell --config /workspaces/$first_workspace/cSpell.json \"/workspaces/$first_workspace/docs/**/*.md\" --no-progress"' >> ~/.bashrc
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias lint="markdownlint-cli2-config /workspaces/$first_workspace/.github/linters/.markdownlint.yml /workspaces/$first_workspace/docs/**/*.md"' >> ~/.bashrc
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias build="docfx /workspaces/$first_workspace/docs/docfx.json"' >> ~/.bashrc
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias serve="docfx /workspaces/$first_workspace/docs/docfx.json --serve"' >> ~/.bashrc
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias snippets="dotnet test /workspaces/$first_workspace/docs/snippets/Snippets.sln"' >> ~/.bashrc
