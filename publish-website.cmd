rem --------------------------------------------
rem publish website to github pages
rem --------------------------------------------

rem ::Important::: please set GIT_USER env in your computer

cd website

cmd /C "set "GIT_USER=%GIT_USER%" && yarn deploy"

pause

