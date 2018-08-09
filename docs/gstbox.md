
## Nas Storage infrastructure

```ascii
            KmlApp                                     NextCloud
          ________                                     ________
         |==|=====|                                   |==|=====|
         |  |     |                                   |  |     |
         |  |     |<--------------------------------- |  |     |
         |  |     |                                   |  |     |
         |  |     |                                   |  |     |
         |  |====°|---------------------------------> |  |====°|
         |__|_____|                                   |__|_____|

        .----------.                                 .----------.
       ( IntegraDev )                               ( IntegraBox )
        '----------'                                 '----------'
```        
#### NextCloud
the source are as private under apache service
```rc
/var/www/nextcloud/public_html/gstcloud/
```

config apache Vhost

```Apache2
	ServerAdmin webmaster@localhost
	ServerName nextcloud
	ServerAlias nextcloud
	DocumentRoot /var/www/nextcloud/public_html
```

file /etc/hosts

```rc

192.168.20.100   integradev nextcloud cloud devel
187.141.67.234	 integradev nextcloud cloud devel

```


#### IntregraBox

restart service nfs4

``` bash
sudo service nfs-kernel-server restart

```
mount resources from IntregraBox ==> IntegraDev


#### IntegraDev
```rc
integrabox:/media/storage/shared            nfs4      2.0T   15G  2.0T   1% /var/www/nextcloud/public_html/gstcloud/data
```
command
``` bash
sudo mount.nfs -vv integrabox:/media/storage/shared/ data/
```
