pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build -c Release'
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

        		rmdir /S /Q C:\\inetpub\\incusmart || echo not exist
        		mkdir C:\\inetpub\\incusmart
        		xcopy publish C:\\inetpub\\incusmart /E /I /Y

        		%windir%\\system32\\inetsrv\\appcmd start apppool /apppool.name:IncuSmartPool
        		'''
    		}
	}
    }
}
