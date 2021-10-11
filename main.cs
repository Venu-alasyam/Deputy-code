using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Output
{
    // function to check if the 1st role is parent of 2nd role
    public static bool isParent(Role[] roles, int r1, int r2)
    {

        // find immediate parent of r2
        int parent = -1;
        for (int i = 0; i < roles.Length; i++)
        {

            // check if role[i] matches with r2
            if (roles[i].id == r2)
            {
                parent = roles[i].parent;
                break;
            }
        }

        // check if parent of r2 is 0 => no parent
        if (parent == 0)
        {
            return false;
        }

        // check for parent match
        if (parent == r1)
        {
            return true;
        }

        // if no match, search for the parent of parent of r2
        return isParent(roles, r1, parent);
    }

    // function to demontrate the required logic
    // input parameters - collection of roles and users, user id
    // output - gives a list of users subordinate to the given user id

    //Test cases
    [DataTestMethod]
    [DataRow(new object[] { 1, "System Administrator", 0 }, new object[] { 1, "Adam Admin", 1 }, 1)]
    [DataRow(new object[] { 3, "Supervisor", 2 }, new object[] { 3, "Sam Supervisor", 3 }, 3)]
    [DataRow(new object[] { 4, "Employee", 3 }, new object[] { 2, "Emily Employee", 4 }, 2)]
    [DataRow(new object[] { 2, "Location Manager", 1 }, new object[] { 4, "Mary Manager", 2 }, 4)]
    [DataRow(new object[] { 5, "Trainer", 3 }, new object[] { 5, "Steve Trainer", 5 }, 5)]
    [TestMethod]
    public static List<User> getSubOrdinates(Role[] roles, User[] users, int userId)
    {

        // required list of subordinates
        List<User> subordinates = new List<User>();

        // first find the role of the user with given user id
        int curr_role = -1;
        // loop for all users and find the required user
        for (int i = 0; i < users.Length; i++)
        {

            // check for user id
            if (users[i].id == userId)
            {
                curr_role = users[i].role;
                break;
            }
        }

        // again go through all users
        // and add all those users to a list
        // whose role is direct or indirect child of the current role
        for (int i = 0; i < users.Length; i++)
        {

            // if the condition is true => subordinate
            if (isParent(roles, curr_role, users[i].role))
            {
                subordinates.Add(users[i]);
                // also print for output
                Console.WriteLine(users[i].id + ", " + users[i].name + ", " + users[i].role);
            }
        }

        // return the subordinates list
        return subordinates;
    }
    public static void Main(string[] args)
    {

        // sample run

        // define roles
        Role objRole1 = new Role(1, "System Administrator", 0);
        Role objRole2 = new Role(2, "Location Manager", 1);
        Role objRole3 = new Role(3, "Supervisor", 2);
        Role objRole4 = new Role(4, "Employee", 3);
        Role objRole5 = new Role(5, "Trainer", 3);
        Role[] roles = new Role[] { objRole1, objRole2, objRole3, objRole4, objRole5 };

        // define users
        User objUser1 = new User(1, "Adam Admin", 1);
        User objUser2 = new User(2, "Emily Employee", 4);
        User objUser3 = new User(3, "Sam Supervisor", 3);
        User objUser4 = new User(4, "Mary Manager", 2);
        User objUser5 = new User(5, "Steve Trainer", 5);
        User[] users = new User[] { objUser1, objUser2, objUser3, objUser4, objUser5 };

        // check for user # 1, 2, 3, 4, 5
        List<User> subordinates;
        Console.WriteLine(".......... For user # 1 ..........");
        subordinates = getSubOrdinates(roles, users, 1);
        Console.WriteLine(".......... For user # 2 ..........");
        subordinates = getSubOrdinates(roles, users, 2);
        Console.WriteLine(".......... For user # 3 ..........");
        subordinates = getSubOrdinates(roles, users, 3);
        Console.WriteLine(".......... For user # 4 ..........");
        subordinates = getSubOrdinates(roles, users, 4);
        Console.WriteLine(".......... For user # 5 ..........");
        subordinates = getSubOrdinates(roles, users, 5);
        //Expected value, Actual value
        Assert.AreEqual(subordinates, subordinates);

    }
}
