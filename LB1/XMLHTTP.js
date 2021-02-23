var xmlRequest;
try
{
    xmlRequest = new XMLHttpRequest();
    xmlRequest.open("POST", "FAA4.cs");
}
catch(err)
{
    xmlRequest = new ActiveXObject("Microsoft.XMLHTTP");
}