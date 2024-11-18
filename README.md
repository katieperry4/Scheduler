## Appointment Scheduler
This application uses WinForms to create a desktop application that allows the users to add/edit/delete customers, view their calendar, add/edit/delete appointments, and view reports.
It uses MySql to store the data.

# Functionalities
-Detects user's location and timezone. An example was hard coded in to detect users in France; the login page gets translated into French.

-CRUD actions for customers and appointments.

-If the user or customer has conflicting appointments, the appointment cannot be scheduled.

-If the appointment is being scheduled outside 9-5 EST, the appointment cannot be scheduled. Accounts for DST too.

-The user has a calendar view showing their appointments (total, monthly, and weekly).

-Reports for type of appointment and month, all appointments by user, and total appointments by day.


# Visuals
Application Login page:

![Scheduler](https://imgur.com/jpzLaQr.jpg)

Main Menu:

![Scheduler](https://imgur.com/uFQ5s4t.jpg)

Customer Page:

![Scheduler](https://imgur.com/NWRwO8G.jpg)

Calendar Page:

![Scheduler](https://imgur.com/0Xh2dbP.jpg)

Appointments Page:

![Scheduler](https://imgur.com/Fdk8GEP.jpg)

Appointment Conflict:

![Scheduler](https://imgur.com/DZHhEWW.jpg)

Reports Page:

![Scheduler](https://imgur.com/XyBz9uF.jpg)
