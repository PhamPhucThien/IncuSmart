pipeline {
    agent any

    options {
        skipDefaultCheckout(true)
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore IncuSmart.sln'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build IncuSmart.sln -c Release --no-restore'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish IncuSmart.App\\IncuSmart.App.csproj -c Release -o publish'
            }
        }

        stage('Deploy') {
            steps {
                bat '''
                %windir%\\system32\\inetsrv\\appcmd stop apppool /apppool.name:IncuSmartPool

                if not exist C:\\inetpub\\incusmart (
                    mkdir C:\\inetpub\\incusmart
                )

                xcopy publish C:\\inetpub\\incusmart /E /I /Y

                %windir%\\system32\\inetsrv\\appcmd start apppool /apppool.name:IncuSmartPool
                '''
            }
        }
    }
}
