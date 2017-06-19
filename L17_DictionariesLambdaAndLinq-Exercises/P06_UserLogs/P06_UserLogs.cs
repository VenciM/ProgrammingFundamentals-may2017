﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_UserLogs
{
    class P06_UserLogs
    {
        static void Main(string[] args)
        {
            var userIpMessageCount = new SortedDictionary<string, Dictionary<string, int>>();
            var command = Console.ReadLine();

            while (command != "end")
            {
                GetUserIpMsgCount(userIpMessageCount, command);

                command = Console.ReadLine();
            }

            foreach (var user in userIpMessageCount)
            {
                Console.WriteLine($"{user.Key}:");
                var ipCountList = NewMethod(userIpMessageCount, user);
                Console.WriteLine($"{string.Join(", ", ipCountList)}.");
            }
        }

        static void GetUserIpMsgCount(
            SortedDictionary<string, Dictionary<string, int>> userIpMessageCount,
            string command)
        {
            var commandLineList = command.Split(' ').ToList();
            var ipAddress = commandLineList[0].Substring(3);
            var user = commandLineList[2].Substring(5);

            if (!userIpMessageCount.ContainsKey(user))
            {
                userIpMessageCount[user] = new Dictionary<string, int>();
            }
            if (!userIpMessageCount[user].ContainsKey(ipAddress))
            {
                userIpMessageCount[user][ipAddress] = 0;
            }
            userIpMessageCount[user][ipAddress]++;
        }

        static List<string> NewMethod(
            SortedDictionary<string, Dictionary<string, int>> userIpMessageCount,
            KeyValuePair<string, Dictionary<string, int>> user)
        {
            var tempIpList = new List<string>();
            foreach (var ipCount in userIpMessageCount[user.Key])
            {
                tempIpList.Add($"{ipCount.Key} => {ipCount.Value}");
            }

            return tempIpList;
        }
    }
}
