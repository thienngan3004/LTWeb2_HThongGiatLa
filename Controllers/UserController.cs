using Microsoft.AspNetCore.Mvc;
using Buoi2.DTOs;

namespace Buoi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<UserResponseDto> _fakeUsers = new List<UserResponseDto>
        {
            new UserResponseDto
            {
                Id = 1,
                Username = "nguyenvana",
                Email = "ana@gmail.com",
                Role = "User",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new UserResponseDto
            {
                Id = 2,
                Username = "tranvanb",
                Email = "banb@gmail.com",
                Role = "User",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new UserResponseDto
            {
                Id = 3,
                Username = "lethic",
                Email = "c@gmail.com",
                Role = "User",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new UserResponseDto
            {
                Id = 4,
                Username = "phamhoangnam",
                Email = "nam@gmail.com",
                Role = "Admin",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new UserResponseDto
            {
                Id = 5,
                Username = "nguyenminhduc",
                Email = "duc@gmail.com",
                Role = "User",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            },

            new UserResponseDto
            {
                Id = 6,
                Username = "voquanghuy",
                Email = "huy@gmail.com",
                Role = "User",
                CreatedAt = DateTime.UtcNow,
                IsActive = false
            }
        };


        // =========================
        // GET: Lấy tất cả User
        // GET: api/User
        // =========================
        [HttpGet]
        public ActionResult<List<UserResponseDto>> GetAll()
        {
            return Ok(_fakeUsers);
        }


        // =========================
        // GET: Lấy User theo Id
        // GET: api/User/1
        // =========================
        [HttpGet("{id:int}")]
        public ActionResult<UserResponseDto> GetById(int id)
        {
            var user = _fakeUsers.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new
                {
                    message = $"Không tìm thấy người dùng có Id = {id}"
                });
            }

            return Ok(user);
        }

        // =========================
        // GET: Lọc User theo Role
        // GET: api/User/filter/role/User
        // GET: api/User/filter/role/Admin
        // =========================
        [HttpGet("filter/role/{role}")]
        public ActionResult<List<UserResponseDto>> FilterByRole(string role)
        {
            var users = _fakeUsers
                .Where(u => u.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (users.Count == 0)
            {
                return NotFound(new
                {
                    message = $"Không tìm thấy User có Role = {role}"
                });
            }

            return Ok(users);
        }

        // =========================
        // GET: Tìm kiếm User
        // GET: api/User/search?keyword=nguyen
        // =========================
        [HttpGet("search")]
        public ActionResult<List<UserResponseDto>> Search(string? keyword)
        {
            // Không nhập keyword → trả về toàn bộ User
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return Ok(_fakeUsers);
            }

            // Có keyword → tìm theo Username hoặc Email
            var users = _fakeUsers
                .Where(u =>
                    u.Username.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    u.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (users.Count == 0)
            {
                return NotFound(new
                {
                    message = $"Không tìm thấy User với từ khóa: {keyword}"
                });
            }

            return Ok(users);
        }

        // =========================
        // POST: Thêm User
        // POST: api/User
        // =========================
        [HttpPost]
        public ActionResult<UserResponseDto> Add(UserResponseDto request)
        {
            request.Id = _fakeUsers.Max(u => u.Id) + 1;
            request.CreatedAt = DateTime.UtcNow;

            _fakeUsers.Add(request);

            return CreatedAtAction(
                nameof(GetById),
                new { id = request.Id },
                request
            );
        }


        // =========================
        // PUT: Cập nhật User
        // PUT: api/User/1
        // =========================
        [HttpPut("{id:int}")]
        public ActionResult<UserResponseDto> Update(
            int id,
            UserResponseDto request)
        {
            var user = _fakeUsers.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new
                {
                    message = $"Không tìm thấy người dùng có Id = {id}"
                });
            }

            user.Username = request.Username;
            user.Email = request.Email;
            user.Role = request.Role;
            user.IsActive = request.IsActive;

            return Ok(user);
        }


        // =========================
        // DELETE: Xóa User
        // DELETE: api/User/1
        // =========================
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var user = _fakeUsers.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new
                {
                    message = $"Không tìm thấy người dùng có Id = {id}"
                });
            }

            _fakeUsers.Remove(user);

            return Ok(new
            {
                message = $"Đã xóa người dùng có Id = {id}"
            });
        }
    }
}