@echo off
set URL=https://sod2.superoffice.com/Cust36280/default.aspx
set DIR=%0\..
set BASE=%DIR%\..
set YML=%BASE%\Build\Webshots
set EXE=%BASE%\tools\WebShooter\WebShooter.exe
set LoginUsername=xxx
set LoginPassword=yyy

%EXE% -v  %YML%\Login.yml %YML%\Media.yml -u %URL% -o %BASE%\en -p Lang=en
%EXE% -v  %YML%\Login.yml %YML%\Media.yml -u %URL% -o %BASE%\sv -p Lang=sv
