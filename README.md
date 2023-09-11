# Labb3
School database assignment from SQL course

# About the task:

This lab builds upon Lab 2, so you will be working with the same database you created there.

**You are allowed, if you wish, to make changes to the structure and design of the database for this task!**

# What you need to do:

- [ ] Populate your database from Lab 2 with more sample data in all tables.
- [ ] Create a new console program in C#.
- [ ] Create a simple navigation in the program that allows the user to choose between the following functions:
    - [ ] Retrieve staff members (to be solved with SQL)
        
        The user can choose whether they want to see all employees or only those within a specific category, such as teachers.
        
    - [ ] Retrieve all students (to be solved with Entity Framework)
        
        The user can choose to see the students sorted by first or last name and in ascending or descending order.
        
    - [ ] Retrieve all students in a specific class (to be solved with Entity Framework)
        
        The user should first see a list of all classes available. Then, the user can select one of the classes, and all students in that class will be displayed.
        
        Extra Challenge: Allow the user to choose the sorting of students as in the previous point.
        
    - [ ] Retrieve all grades given in the last month (to be solved with SQL)
        
        Here, the user will immediately receive a list of all grades given in the past month, including the student's name, course name, and grade.
        
    - [ ] Retrieve a list of all courses and the average grade students have received in that course, as well as the highest and lowest grade received in the course (to be solved with SQL)
        
        Here, the user will immediately see a list of all courses in the database, along with the average grade, the highest grade, and the lowest grade for each course.
        
        Tip: It can be challenging to do this with letter grades, so you may choose to store grades as numbers instead.
        
    - [ ] Add new students (to be solved through SQL)
        
        The user is given the opportunity to enter information about a new student, and that data is then saved in the database.
        
    - [ ] Add new staff members (to be solved through Entity Framework)
        
        The user is given the opportunity to enter information about a new employee, and that data is then saved in the database.
        
**Extra Challenges**

- Validate that social security numbers (personnumren) are valid using SQL.
- Build a view to retrieve grades given in the last month.
- Build an additional function for the user where they can calculate the average grade based on gender and age group/year group, considering the average for all the courses they have taken.
