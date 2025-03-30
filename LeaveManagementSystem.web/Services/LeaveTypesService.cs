using AutoMapper;
using LeaveManagementSystem.web.Data;
using LeaveManagementSystem.web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.web.Services;

public class LeaveTypesService(ApplicationDbContext context, IMapper mapper) : ILeaveTypesService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;
    
    public async Task<List<LeaveTypeReadOnlyVM>> GetAllAsync()
    {
        var data = await _context.LeaveTypes.ToListAsync();
        return _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
    }
    
    public async Task<T> GetTypeByIdAsync<T>(int id) where T : class
    {
        var leaveType = await _context.LeaveTypes
            .FirstOrDefaultAsync(m => m.Id == id);
        if (leaveType == null)
        {
            return null;
        }
        
        return _mapper.Map<T>(leaveType);
    }
    
    public async Task RemoveAsync(int id)
    {
        var leaveType = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id);
        if (leaveType != null)
        {
            _context.LeaveTypes.Remove(leaveType);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task EditAsync(LeaveTypeEditVM leaveTypeEdit)
    {
        var leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }
    
    public async Task CreateAsync(LeaveTypeCreateVM leaveTypeCreate)
    {
        var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }
    
    
    
    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
        
    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(name.ToLower()));
    }
        
    public async Task<bool> CheckIfLeaveTypeNameExists(LeaveTypeEditVM leaveTypeEdit)
    {
        return await _context.LeaveTypes.AnyAsync(e => e.Name.ToLower().Equals(leaveTypeEdit.Name.ToLower()) && e.Id != leaveTypeEdit.Id);
    }
}