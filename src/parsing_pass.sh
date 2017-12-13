#!/bin/bash
# Read Password
echo -n Password:
#read -s password
read -s -p "Password:" pekas
echo
# Run Command
sudo ifconfig $password


# Assume $remote_server, $my_user_id, $my_password, and $my_command were read in earlier
# in the script.
# Open a telnet session to a remote server, and wait for a username prompt.
spawn telnet $remote_server
expect "username:"
# Send the username, and then wait for a password prompt.
send "$my_user_id\r"
expect "password:"
# Send the password, and then wait for a shell prompt.
send "$my_password\r"
expect "%"
# Send the prebuilt command, and then wait for another shell prompt.
send "$my_command\r"
expect "%"
# Capture the results of the command into a variable. This can be displayed, or written to disk.
set results $expect_out(buffer)
# Exit the telnet session, and wait for a special end-of-file character.
send "exit\r"
expect eof

example two
#!/bin/bash
echo "TOP: Now start expecting things"

/usr/bin/expect  -f - <<EOD
set timeout 5
spawn sudo xcodebuild -license
send "\r"
expect {
    "By typing 'agree' you are agreeing" {
        send "agree\r\n"
    }
    "Software License Agreements Press 'space' for more, or 'q' to quit" {
        send " ";
        exp_continue;
    }
    timeout {
        send_user "\nTimeout 2\n";
        exit 1
    }
}
expect {
    timeout {
        send_user "\nFailed\n";
        exit 1
    }
}
EOD



# bash with expect

spawn dbe

expect "Password:"

send "@EnumaElish#"
