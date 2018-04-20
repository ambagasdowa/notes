#!/bin/bash
#
# L Nix <lornix@lornix.com>
# setup-bt-kb : allow choosing & pairing a bluetooth keyboard from the console
#
declare -a addrlist
#
while [ 1 ]; do
    echo -n "Scanning for Bluetooth devices ... "
    readarray -n 10 -O 0 -t addrlist < <(hcitool scan|grep -v "^Scanning"|sed -e "s/^[ \t]//g" -e "s/\t/ /g" | head -n 9)
    echo
    echo
    length=${#addrlist[@]}
    a=1
    while [ ${a} -le ${length} ]; do
        echo "$a) ${addrlist[$a-1]}"
        a=$((a + 1))
    done
    echo
    while [ 1 ]; do
        if [ ${length} -gt 0 ]; then
            echo -n "Choose (1-${length}), or "
        fi
        echo -n "'R' to rescan: "
        read -n 1 REPLY
        echo
        case ${REPLY} in
            Q)
                # just quit
                exit 0
                ;;
            [0rR])
                echo
                REPLY=0
                break
                ;;
            [123456789])
                if [ ${REPLY} -le ${length} ]; then
                    echo "Got ${REPLY}"
                    break
                fi
                ;;
            *)
                ;;
        esac
    done
    if [ ${REPLY} -gt 0 ]; then
        break
    fi
done
#
device=${addrlist[${REPLY}-1]}
#
BTADDR=${device/% *}
BTNAME=${device/#??:??:??:??:??:?? }
#
echo "selecting '${BTNAME}' at ${BTADDR}"
#
echo "Pairing with ${BTNAME} (Generally '0000')"
bluez-simple-agent hci0 ${BTADDR}
#
echo "Setting trust level with ${BTNAME}"
bluez-test-device trusted ${BTADDR} yes
#
echo "Connecting to ${BTNAME}"
bluez-test-input connect ${BTADDR}
#
echo "Completed"
