rem --------------------------------------------
rem publish website to github pages
rem --------------------------------------------

rem ::Important::: please set GIT_USER env in your computer


cd website

rem build
npm run build

rem deploy
yarn deploy

pause

