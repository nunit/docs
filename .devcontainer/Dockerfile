FROM mono:latest

RUN apt update -yqq \
    && apt install -yqq gpg apt-transport-https \
    && curl -o - https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > /etc/apt/trusted.gpg.d/microsoft.asc.gpg \
    && curl -o /etc/apt/sources.list.d/microsoft-prod.list https://packages.microsoft.com/config/debian/9/prod.list \
    && chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg \
    /etc/apt/sources.list.d/microsoft-prod.list \
    && apt update -yqq \
    && apt install -yqq \
    unzip \
    git \
    dotnet-sdk-3.1 \
    && rm -rf /var/lib/apt/lists/*

ENV PATH="/docfx:${PATH}"
ENTRYPOINT [ "docfx" ]

ADD ./entrypoint.sh /usr/local/bin/docfx

EXPOSE 8080

ADD https://github.com/dotnet/docfx/releases/download/v2.57.1/docfx.zip /
RUN unzip docfx.zip -d /docfx && \
    rm docfx.zip