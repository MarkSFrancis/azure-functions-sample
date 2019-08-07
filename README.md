# Azure Functions
This is a sample Azure Functions project

# Getting Started

This project uses the [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local) to debug on local, and runs [dotnet](https://dotnet.microsoft.com). Azure functions also support node, python (preview) and powershel (preview) functions, but this project is not using them. 

## Installing the Azure Functions Core Tools

Additional information is available in the Azure Functions Core Tools [docs](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)

#### Windows (requires [Node](https://nodejs.org/en/))
```sh
npm install -g azure-functions-core-tools
```

#### OS X (requires [Homebrew](https://brew.sh))
```sh
brew tap azure/functions
brew install azure-functions-core-tools
```

#### Linux (Ubuntu/Debian)
```sh
curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-$(lsb_release -cs)-prod $(lsb_release -cs) main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-get update
sudo apt-get install azure-functions-core-tools
```

