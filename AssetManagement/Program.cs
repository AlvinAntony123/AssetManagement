using AssetManagementAPI;
using AssetManagementAPI.ControllerServices;
using AssetManagementAPI.Models;
using AssetManagementAPI.ServiceInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AssetDbContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"), ServiceLifetime.Singleton);

builder.Services.AddSingleton<IRepository<City>, SqlDbRepository<City>>();
builder.Services.AddSingleton<IRepository<Asset>, SqlDbRepository<Asset>>();
builder.Services.AddSingleton<IRepository<Building>, SqlDbRepository<Building>>();
builder.Services.AddSingleton<IRepository<Department>, SqlDbRepository<Department>>();
builder.Services.AddSingleton<IRepository<Employee>, SqlDbRepository<Employee>>();
builder.Services.AddSingleton<IRepository<Facility>, SqlDbRepository<Facility>>();
builder.Services.AddSingleton<IRepository<MeetingRoom>, SqlDbRepository<MeetingRoom>>();
builder.Services.AddSingleton<IRepository<Cabin>, SqlDbRepository<Cabin>>();
builder.Services.AddSingleton<IRepository<Seat>, SqlDbRepository<Seat>>();
builder.Services.AddSingleton<IRepository<MeetingRoomAsset>, SqlDbRepository<MeetingRoomAsset>>();
builder.Services.AddSingleton<IRepository<Overview>,  SqlDbRepository<Overview>>();
builder.Services.AddSingleton<IRepository<UnallocatedViewModel>, SqlDbRepository<UnallocatedViewModel>>();
builder.Services.AddSingleton<IRepository<FacilityViewModel>, SqlDbRepository<FacilityViewModel>>();
builder.Services.AddSingleton<IRepository<CabinAllocatedViewModel>,  SqlDbRepository<CabinAllocatedViewModel>>();
builder.Services.AddSingleton<IRepository<CabinUnallocatedViewModel>, SqlDbRepository<CabinUnallocatedViewModel>>();

builder.Services.AddSingleton<ISeatService, SeatService>();
builder.Services.AddSingleton<IAssetService, AssetService>();
builder.Services.AddSingleton<IBuildingService, BuildingService>();
builder.Services.AddSingleton<ICabinService, CabinService>();
builder.Services.AddSingleton<ICityService, CityService>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IFacilityService, FacilityService>();
builder.Services.AddSingleton<IMeetingRoomAssetService, MeetingRoomAssetService>();
builder.Services.AddSingleton<IMeetingRoomService, MeetingRoomService>();
builder.Services.AddSingleton<IReportService, ReportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
