# dnslookup tool

simple c# console tool that performs dns lookups for a given url. the tool extracts the domain name from the provided url and retrieves various dns records associated with it, including:

- a (ipv4)
- mx (mail exchanger)
- ns (name server)
- cname (canonical name)
- txt (text records)
- ptr (pointer)
- soa (start of authority)

## how it works
1. user inputs a url
2. tool extracts the domain from the url.
3. tool retrieves the a (ipv4) address using the `dns.gethostaddresses` method.
4. for other dns record types, it uses the `nslookup` command-line tool.

## requirements
- .net framework (compatible with the version of c# you are using)
- access to `nslookup` command on your machine
+ i really aim only for win10 not linux 


