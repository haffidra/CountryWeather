# CountryWeather
Country weather


Task #1
Using Sequential searching, because no need sorting data first. The task is to search patient contain part of patient name, then need to look all element of array. With ignoring sorting data, searching become faster. If using Binary Search, the data need to be sorted first and it'll take some times and not for search patient contain part of patient name.


Task #2
-Download solution from github
-open in visual studio
-right click on CountryAPI => properties
-on tab "Debug", uncheck "Enable SSL"
-copy port "App URL" (ex:29022)
-go to project web CountryWeather => Controller => HomeController
-on method "GetAllCountry" and "GetCityByCountry", there is link to API URL,change the port with API Port used
-run web and API project
