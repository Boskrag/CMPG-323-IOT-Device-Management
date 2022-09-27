using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository
    {

        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        

        // GET: Devices
        public  List<Device> GetAll()
        {
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return _context.Device.ToList();
        }

        // GET: Devices by ID
        public  async Task<Device> GetById(Guid? id)
        {
            
            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            

            return (device);
        }

       

        // POST: Devices/Create
        
        
        public async Task<Device> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _context.Add(device);
            await _context.SaveChangesAsync();

            return (device);


        }

        // GET: Devices/Edit/5
        public async Task<Device> Edit(Guid? id)
        {

            var device = await _context.Device.FindAsync(id);
               
            return (device);
        }

        // POST: Devices/Edit/5
        
        
        public async Task<Device> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            
            
            
               _context.Update(device);
               await _context.SaveChangesAsync();
            
            
            
            return (device);

        }

        // GET: Devices/Delete/5
        public async Task<Device> Delete(Guid? id)
        {

            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);

            return (device);
        }

        // POST: Devices/Delete/5
        
        public async Task<Device> DeleteConfirmed(Guid id)
        {
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return (device);
        }

    }
}
