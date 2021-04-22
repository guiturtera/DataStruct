set /p commit_message="Escreva a mensagem de commit: "

git add .
git commit -m "%commit_message%"
git push -u origin master