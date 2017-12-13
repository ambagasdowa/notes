#!/bin/bash
echo "TOP: Now start expecting things"

# /usr/bin/expect  -f - <<EOD
# set timeout 5
# spawn sudo mount.davfs http://nextcloud/gstcloud/remote.php/webdav /var/www/development/public_html/kml/app/webroot/vendors/RichFilemanager/userfiles/ambagasdowa/ -o users,rw,noauto,username=ambagasdowa,file_mode=0777,dir_mode=0777
# # send "\r"
# expect {
#     "[sudo] password for ambagasdowa:"{
#       send "pekas\r"
#     }
#     "Password:" {
#         send "@EnumaElish#\r"
#     }
#     timeout {
#         send_user "\nTimeout 2\n";
#         exit 1
#     }
# }
# expect {
#     timeout {
#         send_user "\nFailed\n";
#         exit 1
#     }
# }
# EOD

expect -c '
    spawn sudo mount.davfs http://nextcloud/gstcloud/remote.php/webdav /var/www/development/public_html/kml/app/webroot/vendors/RichFilemanager/userfiles/ambagasdowa/ -o users,rw,noauto,username=ambagasdowa,file_mode=0777,dir_mode=0777
    expect "\[sudo\] password for ambagasdowa: "
    send "pekas\r"
    expect "Password: "
    send '"@EnumaElish#\r"'
    expect "$ "
    send "exit\r"
    expect "$ "
    send "pbrun bash\r"
    expect "$ "
    send "exit\r"
     '
