FROM ghcr.io/nunit/docfx-action:v3.0.0
EXPOSE 8080
ARG NODE_MAJOR=20

### Installing Node LTS into the container
RUN apt-get update
RUN apt-get install -y ca-certificates curl gnupg
RUN mkdir -p /etc/apt/keyrings
RUN curl -fsSL https://deb.nodesource.com/gpgkey/nodesource-repo.gpg.key | gpg --dearmor -o /etc/apt/keyrings/nodesource.gpg

RUN echo "deb [signed-by=/etc/apt/keyrings/nodesource.gpg] https://deb.nodesource.com/node_$NODE_MAJOR.x nodistro main" | tee /etc/apt/sources.list.d/nodesource.list
RUN apt-get update
RUN apt-get install nodejs unzip dos2unix -y

### Installing Node Packages
RUN npm install -g yarn
RUN npm install -g npm
RUN npm install -g cspell
RUN npm install -g markdownlint-cli2

RUN node -v
RUN npm -v
RUN yarn -v

# This script gets the api-docs from the latest NUnit release
COPY get-nunit-apidocs.sh .
RUN dos2unix ./get-nunit-apidocs.sh
RUN chmod +x get-nunit-apidocs.sh

### Add the aliases
# We get the first workspace, because there should only be one
# This is so that when someone updates their devcontainer name, it doesn't get screwed up
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias spellcheck="cspell --config /workspaces/$first_workspace/cSpell.json \"/workspaces/$first_workspace/docs/**/*.md\" --no-progress"' >> ~/.bashrc
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias lint="markdownlint-cli2-config /workspaces/$first_workspace/.github/linters/.markdownlint.yml /workspaces/$first_workspace/docs/**/*.md"' >> ~/.bashrc
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias build="docfx /workspaces/$first_workspace/docs/docfx.json"' >> ~/.bashrc
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias serve="docfx /workspaces/$first_workspace/docs/docfx.json --serve"' >> ~/.bashrc
RUN echo 'first_workspace=\"$(cd /workspaces && ls | head -1)\"; alias snippets="dotnet test /workspaces/$first_workspace/docs/snippets/Snippets.sln"' >> ~/.bashrc

# We load the latest NUnit apidocs at start in case they're needed later
RUN echo 'alias apidocs="bash /get-nunit-apidocs.sh"' >> ~/.bashrc
RUN echo 'apidocs' >> ~/.bashrc