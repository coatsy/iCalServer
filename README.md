# iCalServer

iCalServer is a sample dotNet Core WebAPI implementation of a service serving [iCal](https://en.wikipedia.org/wiki/ICalendar) Calendars.

Much of the structure for the code was taken from a 2012 blog post on [serving ics requests from SharePoint](https://arunjameskc.wordpress.com/2012/10/10/implementing-custom-sharepoint-icalendar-ics-requests-using-httphandler/).

The basic Authentication implemented here is based on Barry Dorans' [idunno.Authentication](https://github.com/blowdart/idunno.Authentication)

## Sample

To see the service in action, add a internet calendar to Outlook with the url

https://icalserver.azurewebsites.net/api/calendar

You'll be prompted for credentials. use anything for the username and `Pass@word1` for the password.

This will give you a 5 event calendar called {your username}'s Internet Calendar.

If you put a user ID in the url, for example

https://icalserver.azurewebsites.net/api/calendar/Suzanne

you'll get a calendar called Suzanne's Internet Calendar

## Architecture

## Setup

## Deployment

## Usage