## Diagram

#### Connection from node to "sala de juntas"

```ascii

       sw1                      sw2     
    __________               __________
   [_...__...°]             [_...__...°]

                                      .--------------------------------------.
                       .--------*<---( Node 14 Up Comming from Sala de Juntas )
                       |              '--------------------------------------'
                       |                             |
       sw3             |        sw4                  |
    __________         |     __________              |
   [_...__...°]        |    [_...__...°]             |
                       v                             |
              .-----------------.                    |   cisco WAP101
             ( Node 14 Up Output )                   '--> |_|_|      
              '-----------------'                        [____°]     
                       |
                       v
                    Router  
                   ________
                  |==|=====|          .-,(  ),-.    
                  |  |     |       .-(          )-.
                  |  |     |----->(    internet    )
                  |  |     |       '-(          ).-'
                  |  |     |           '-.( ).-'    
                  |  |====°|
                  |__|_____|
```

#### Notes
Router is installed in IntegraKvm ip 192.168.20.215

#### Dhcp
Route /etc/dhcp/dhcpd.conf
##### build the dhcp server

``` config
   ddns-update-style none;
   default-lease-time 600;
   max-lease-time 7200;
   log-facility local7;
   option domain-name-servers 8.8.8.8 , 8.8.4.4 ;
   subnet 10.42.44.0 netmask 255.255.255.0{
          interface eno3;
          range 10.42.44.50 10.42.44.200;
          option subnet-mask 255.255.255.0;
          option broadcast-address 10.42.44.255;
          option routers 10.42.44.1;
  }
```

#### firewall rules
 are not persistent

*TODO*
make this rules persistent

``` bash
#!/bin/bash

# firts flush the rules of the firewall
 echo "stopping firewall and allowing everyone ... "
 iptables -F
 iptables -X
 iptables -t nat -F
 iptables -t nat -X
 iptables -t mangle -F
 iptables -t mangle -X
 iptables -P INPUT ACCEPT
 iptables -P FORWARD ACCEPT
 iptables -P OUTPUT ACCEPT

#now set the nat
# this is the ***ing rule for the nat
# after this build the dhclient server for use the sw
modprobe iptable_nat
# iptables -t nat -A POSTROUTING -s 10.42.23.0/24 -o eno2 -j MASQUERADE
# echo 1 > /proc/sys/net/ipv4/ip_forward

#ok now watch this
/etc/init.d/isc-dhcp-server stop
killall dhcpd
sleep 10s

#ifdown eno3
ip addr flush eno3
ifconfig eno3 down

#ip link set wlp3s0 down

#iwconfig wlp3s0 mode Master
#iwconfig wlp3s0 freq 2.422G
#iwconfig wlp3s0 essid "Ambagasdowa Network"

#iw dev wlp3s0 set type AP


ip link set up dev eno3
sysctl net.ipv4.ip_forward=1
sysctl net.ipv6.conf.default.forwarding=1
sysctl net.ipv6.conf.all.forwarding=1
sleep 2
#another approach
 #iptables -t nat -A POSTROUTING -o enp0s25 -j MASQUERADE
 #iptables -A FORWARD -i enp0s25 -o wlp3s0 -j ACCEPT
 #iptables -A FORWARD -m conntrack --ctstate RELATED,ESTABLISHED -j ACCEPT

ifconfig eno3 10.42.44.1/24
iptables -t nat -A POSTROUTING -s 10.42.44.0/24 -o eno2 -j MASQUERADE
iptables -A FORWARD -s 10.42.44.0/24 -o eno2 -j ACCEPT
iptables -A FORWARD -d 10.42.44.0/24 -m state --state ESTABLISHED,RELATED -i eno2 -j ACCEPT

###### route the servers ######

## Corporate Portal
iptables -t nat -A PREROUTING -d 187.141.67.234 -j DNAT --to-destination 192.168.20.100
## database
iptables -t nat -A PREROUTING -d 187.141.67.227 -j DNAT --to-destination 192.168.20.235
##aplications
iptables -t nat -A PREROUTING -d 187.141.67.228 -j DNAT --to-destination 192.168.20.236
##Terminal T1 and T2
iptables -t nat -A PREROUTING -d 187.141.67.229 -j DNAT --to-destination 192.168.20.237
iptables -t nat -A PREROUTING -d 187.141.67.230 -j DNAT --to-destination 192.168.20.238
# tralix
iptables -t nat -A PREROUTING -d 187.141.67.231 -j DNAT --to-destination 192.168.20.239
# IPVX Cisco system
iptables -t nat -A PREROUTING -d 187.141.67.237 -j DNAT --to-destination 192.168.30.4
iptables -t nat -A PREROUTING -d 187.141.67.238 -j DNAT --to-destination 192.168.30.5
## Vigilance Cameras
iptables -t nat -A PREROUTING -d 187.141.67.233 -j DNAT --to-destination 192.168.20.205
## to exchange in teisa ??
#iptables -t nat -A PREROUTING -d 192.168.1.91 -j DNAT --to-destination 189.254.105.67


echo 'INTERFACES=eno3' > /etc/default/dhcp

dhcpd eno3

```

##### ifconfig
``` r
eno2: flags=4163<UP,BROADCAST,RUNNING,MULTICAST>  mtu 1500
        inet 192.168.20.216  netmask 255.255.255.0  broadcast 192.168.20.255
        inet6 fe80::6eae:8bff:fe1e:9f7a  prefixlen 64  scopeid 0x20<link>
        ether 6c:ae:8b:1e:9f:7a  txqueuelen 1000  (Ethernet)
        RX packets 3120233  bytes 3680149334 (3.4 GiB)
        RX errors 0  dropped 32789  overruns 0  frame 0
        TX packets 1501133  bytes 207150733 (197.5 MiB)
        TX errors 0  dropped 0 overruns 0  carrier 0  collisions 0
        device memory 0x91a60000-91a7ffff  

eno3: flags=4163<UP,BROADCAST,RUNNING,MULTICAST>  mtu 1500
        inet 10.42.44.1  netmask 255.255.255.0  broadcast 10.42.44.255
        inet6 fe80::6eae:8bff:fe1e:9f7b  prefixlen 64  scopeid 0x20<link>
        ether 6c:ae:8b:1e:9f:7b  txqueuelen 1000  (Ethernet)
        RX packets 1538042  bytes 213400036 (203.5 MiB)
        RX errors 0  dropped 94  overruns 0  frame 0
        TX packets 2880931  bytes 3647793562 (3.3 GiB)
        TX errors 0  dropped 0 overruns 0  carrier 0  collisions 0
        device memory 0x91a40000-91a5ffff  

lo: flags=73<UP,LOOPBACK,RUNNING>  mtu 65536
        inet 127.0.0.1  netmask 255.0.0.0
        inet6 ::1  prefixlen 128  scopeid 0x10<host>
        loop  txqueuelen 1  (Local Loopback)
        RX packets 152  bytes 14472 (14.1 KiB)
        RX errors 0  dropped 0  overruns 0  frame 0
        TX packets 152  bytes 14472 (14.1 KiB)
        TX errors 0  dropped 0 overruns 0  carrier 0  collisions 0


```

ip a
``` r

1: lo: <LOOPBACK,UP,LOWER_UP> mtu 65536 qdisc noqueue state UNKNOWN group default qlen 1
    link/loopback 00:00:00:00:00:00 brd 00:00:00:00:00:00
    inet 127.0.0.1/8 scope host lo
       valid_lft forever preferred_lft forever
    inet6 ::1/128 scope host
       valid_lft forever preferred_lft forever
2: enp0s29u1u1u5: <BROADCAST,MULTICAST> mtu 1500 qdisc noop state DOWN group default qlen 1000
    link/ether 6e:ae:8b:1e:9f:79 brd ff:ff:ff:ff:ff:ff
3: eno2: <BROADCAST,MULTICAST,UP,LOWER_UP> mtu 1500 qdisc mq state UP group default qlen 1000
    link/ether 6c:ae:8b:1e:9f:7a brd ff:ff:ff:ff:ff:ff
    inet 192.168.20.216/24 brd 192.168.20.255 scope global eno2
       valid_lft forever preferred_lft forever
    inet6 fe80::6eae:8bff:fe1e:9f7a/64 scope link
       valid_lft forever preferred_lft forever
4: eno3: <BROADCAST,MULTICAST,UP,LOWER_UP> mtu 1500 qdisc mq state UP group default qlen 1000
    link/ether 6c:ae:8b:1e:9f:7b brd ff:ff:ff:ff:ff:ff
    inet 10.42.44.1/24 brd 10.42.44.255 scope global eno3
       valid_lft forever preferred_lft forever
    inet6 fe80::6eae:8bff:fe1e:9f7b/64 scope link
       valid_lft forever preferred_lft forever
5: eno4: <BROADCAST,MULTICAST> mtu 1500 qdisc noop state DOWN group default qlen 1000
    link/ether 6c:ae:8b:1e:9f:7c brd ff:ff:ff:ff:ff:ff
6: eno5: <BROADCAST,MULTICAST> mtu 1500 qdisc noop state DOWN group default qlen 1000
    link/ether 6c:ae:8b:1e:9f:7d brd ff:ff:ff:ff:ff:ff

```
