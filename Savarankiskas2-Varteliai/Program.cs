using Savarankiskas2_Varteliai;
using Savarankiskas2_Varteliai.DataSimulation;

CreateUser createUser = new CreateUser();
createUser.CreateUsers();

CreateGates createGates = new CreateGates();
createGates.CreateGate();

CreatePermits createPermits = new CreatePermits();
createPermits.CreatePermit();

CreateRandomDataToProgram createRandomDataToProgram = new CreateRandomDataToProgram();                  //Sugeneruoja atsitiktinius bandymus praeiti pro vartus
createRandomDataToProgram.CreateRandomData();

ReportService reportService = new ReportService();
reportService.PrintList();                              //Spausdina visa Log'u sarasa i Console
reportService.GetDataFromLogs();                        //Generuoja ataskaita su isdirbtu laiku i HTML