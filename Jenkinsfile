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
    }
}
