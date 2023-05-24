using MK97_FarzadSoltani_HW4.Entities;
using MK97_FarzadSoltani_HW4.Infra;

Users users = new Users()
{
    UserName = "farzad",
    Mobile = "09123997650",
    BirthDate = new DateTime(1990,10,19).Date
};

UsersCreator userCreator = new UsersCreator();
userCreator.Insert(users);
