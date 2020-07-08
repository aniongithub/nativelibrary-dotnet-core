FROM ubuntu:18.04

ARG CONFIGURATION="Debug"
ARG ARCH="x64"

# Install some basic tools
RUN apt-get update &&\
    apt-get install -y \
    nano wget build-essential git

# Install .NET Core SDK 3.1
RUN wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb &&\
    dpkg -i packages-microsoft-prod.deb &&\
    apt-get update &&\
    apt-get install -y apt-transport-https &&\
    apt-get update &&\
    apt-get install -y dotnet-sdk-3.1

# Install latest LLVM/Clang packages
# From: https://apt.llvm.org/
RUN apt-get install -y lsb-release software-properties-common &&\
    bash -c "$(wget -O - https://apt.llvm.org/llvm.sh)"

# Build and install CoreRT from source
RUN apt-get update &&\
    # Pre-requisites
    apt-get install -y \
    llvm cmake clang libicu-dev uuid-dev libcurl4-openssl-dev zlib1g-dev libkrb5-dev libtinfo5 &&\
    # Get the source
    cd /usr/local/src &&\
    git clone https://github.com/dotnet/corert.git &&\
    cd corert &&\
    # Build
    ./build.sh clean ${CONFIGURATION}

# Ensure it can be used from our projects
ENV IlcPath=/usr/local/src/corert/bin/Linux.${ARCH}.${CONFIGURATION}