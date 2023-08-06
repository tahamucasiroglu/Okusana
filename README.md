# Proje Notlar�


fluent validation attribute oluyor



blog ve di�erlerindeki d�n��lerde sayfalama ekle. 
�oklu s�n�f yap�s�na bak yani actionlara yanlar�na PagenatiopnModel gibi ekleme olur mu bak


basede authorize ekledin onun configlerini ayarla test et sonra sikir git FE yap aray�z yok elde

### Notlar

* dotnet ef migrations add 1_test_mig -> migleme
* dotnet ef database update -> push db
* <del>min pool size 0 olmamal� hata veriyor nedene bakars�n</del>
* IsRequired lar galiba zaten true onlar� klad�r olmad� �imdilik garanti i�in kals�n

### Yap�lacaklar

* entitler doldurulacaklar.
* entitlere configleri haz�rla ve index hasdata totable gibi �eyleri detayl�ca haz�rla
* <del> Idler guid oalcak </del>
* kategory - user - userstatus - blog - ekle ek olarak t�klama say�s� fantazi  istersek apriori algosu filan eklenebilir.
* az �z fonsiyon olmal�
* admin i�in post ekleme sayfas�
* mvvm kullanmaya �al��
* postgresql vs sql server farklar�n� ara�t�r
* dok�manlarda ef core ile ilgili ara�t�rmalar� yap
* gen�ay�n videolar� bak
* JWT k�sm�n� d���n
* DB i�in kontrolleri yap ve s�rekli geli�tirme haz�rla oras� en dertli yer
* fluent validation yap attributeleri turkcell kullanm�yor oraya uyum sa�lamal�s�n. Attribute ikna ettin ama fluent olmal� kullanrak yapman laz�m ben mimar de�ilim. Hen�z :D
* react js dal�nacak fakat �nce BE sonra komple FE girilecek ve t�k�r�len yalanacak 
* t�klamalarda istatistik kullan�labbilir �u ilden �u ya�tan �u kadar giri� gibi sonra olur bu
* blog eklemede resim ekleme, belirli tarihte ekleme, yaz� tipi ayarlamalar�, gibi wordpress �eyleri yap hatta wordpress ile yap�lan blog sitesi gibi admin edit�r ve kullan�c� k�sm� yap.
* bloglarda IsRequired zaten true mu� onlara bak sonarcube de hata vermese bile git test et olmad� kald�r gereksiz kod
* postgresql in i�inde bir s�r� farkl�l�klar var sql server a g�re bak sonra ona g�re optimize et 
* bloglarda publicationDate i�in kontrol ekle i�te vakti gelince yay�nlas�n ama buras� nas�l olacak hangfire yapar m� bilemedinm.
* db de userid gibi �eyleri ef kendi ayarl�yor onlar� ilerde kald�r �imdi kar��acak kals�n
* yorumlar�da recursive yap yoruma yorum yaps�nlar
* baz� yerlerde view eklebilir
* BlogTag i�in ol ara sistemde Core lar ile �al���lmas� laz�m bak�n
* servislere sonradan mail servisi eklemeyi dene
* CQRS yap�s� eklemeyi deneyebilrisin
* <del> �zel IServicelerde IActionresult d�n kalanlar�n� oradan kullan. </del>
* <del> servisler httpstatus d�necek </del>

### sorulacaklar
* validationdaki Isrequired i�indeki isrequired durmal� m� amac� config te require true dan false olursa exception f�rlat�p hat�rlatmak
* abstractservice ve abstractrepositorylerdeki par�alamalar mant�kl� m� 
* take hatas� sebebi nedir
* user tablosunda emaili de key yaparak herkesin farkl� email e sahip olmas� garantilenecek ama baseden gelen Id sonras� hata veriyor. birle�tirme yolu var m�
* bu jwt token� program.cs i�inde tan�mlad�ktan sonra oradaki ayarlarla nas�l kullanaca��z nette s�zg�n bir sonu� bulamad�m herkes iki kere jwt token �retici yapm��






using AutoMapper;
using Okusana.Abstract.Repository.Base;
using Okusana.Abstract.Service.Base;
using Okusana.DTOs.Abstract;
using Okusana.Entities.Abstract;
using Okusana.Returns.Abstract;
using Okusana.Returns.Concrete;
using Okusana.Mapper.Extensions;
using Okusana.Extensions;
using Microsoft.AspNetCore.Mvc;
using Okusana.Models.ResponseModel;
using Okusana.Abstract.Models.PaginationModel;
using Okusana.Abstract.Models.HateoasModel;
using Okusana.Models.HateoasModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Okusana.DTOs.Concrete.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using static Okusana.Constants.DbSettings.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace Okusana.DbService.Base
{
    abstract public class AbstractService : IService
    {
        public IActionResult EmptyDataReturn<TCheck, TEntity>(string? Message = null, IHateoas? IHateoas = null, IPagination? pagination = null) => new OkObjectResult(new Response<TCheck>(new SuccessReturnModel<TCheck>("Data is null " + Message), "Ba�ar�yla d�nd�rme sa�land� fakat data null", IHateoas, pagination));
        public IActionResult EmptyDataReturn(string? Message = null, IHateoas? IHateoas = null, IPagination? pagination = null) => new OkObjectResult(new Response( "Ba�ar�yla d�nd�rme sa�land� fakat data null <->" + Message, IHateoas, pagination));

        public IActionResult ErrorDataReturn<TCheck>(string? Message = null, Exception? exception = null) => new BadRequestObjectResult(new Response<TCheck>(new ErrorReturnModel<TCheck>(Message, exception)));
        public IActionResult ErrorDataReturn(string? Message = null, Exception? exception = null) => new BadRequestObjectResult(new Response(Message + exception?.Message));

        public IActionResult NotFoundReturn<TCheck>(string? Message = null, Exception? exception = null) => new NotFoundObjectResult(new Response<TCheck>(new ErrorReturnModel<TCheck>(Message, exception)));

        public virtual IActionResult ReturnEmptyError<T>(string? Message = null) => new BadRequestObjectResult(new ErrorReturnModel<T>(Message));
        /// <summary>
        /// T�m servis d�n��lerini kontrol etmek ve kolayca d�n��t�rmek i�in kullan�lan yard�mc� bir method.
        /// </summary>
        /// <typeparam name="TCheck">D�n��t�r�lecek DTO tipini belirten IDto t�retilmi� s�n�f.</typeparam>
        /// <typeparam name="Entity">Db'den d�nen verinin tipini belirten IEntity t�retilmi� s�n�f.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya d�n��t�r�lecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO d�n���m�nde kullan�lacak IMapper nesnesi.</param> 
        /// <returns>D�n��t�r�len sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IActionResult ConvertToReturn<TCheck, TEntity>(IReturnModel<TEntity> result, IMapper mapper, IHateoas? hateoas = null, IPagination? pagination = null)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null ?
                    EmptyDataReturn<TCheck, TEntity>(result.Message, hateoas, pagination) :
                    new OkObjectResult(new Response<TCheck>(new SuccessReturnModel<TCheck>("Data not null " + result.Message, result.Data.ConvertToDtoCustom<TCheck>(mapper)), "Ba�ar�yla d�nd�rme sa�land� data null de�il", hateoas, pagination));
            }
            else
            {
                return ErrorDataReturn<TCheck>(result.Message, result.Exception);
            }
        }
        /// <summary>
        /// T�m servis d�n��lerini kontrol etmek ve kolayca d�n��t�rmek i�in kullan�lan yard�mc� bir method.
        /// </summary>
        /// <typeparam name="TCheck">D�n��t�r�lecek DTO tipini belirten IDto t�retilmi� s�n�f.</typeparam>
        /// <typeparam name="Entity">Db'den d�nen verinin tipini belirten IEntity t�retilmi� s�n�f.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya d�n��t�r�lecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO d�n���m�nde kullan�lacak IMapper nesnesi.</param> 
        /// <returns>D�n��t�r�len sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IActionResult ConvertToReturn<TCheck, TEntity>(IReturnModel<IEnumerable<TEntity>> result, IMapper mapper, IHateoas? hateoas = null, IPagination? pagination = null)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null ?
                    EmptyDataReturn<IEnumerable<TCheck>, TEntity>(result.Message, hateoas, pagination) :
                    new OkObjectResult(new Response<IEnumerable<TCheck>>(new SuccessReturnModel<IEnumerable<TCheck>>("Data not null " + result.Message, result.Data.ConvertToDtoCustom<TCheck>(mapper)), "Ba�ar�yla d�nd�rme sa�land� data null de�il", hateoas, pagination));
            }
            else
            {
                return ErrorDataReturn<IEnumerable<TCheck>>(result.Message, result.Exception);
            }
        }

        public virtual IActionResult ConvertToReturn<TEntity>(IReturnModel<TEntity> result, IHateoas? hateoas = null, IPagination? pagination = null)
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null ?
                    EmptyDataReturn(result.Message, hateoas, pagination) :
                    new OkObjectResult(new Response<TEntity>(new SuccessReturnModel<TEntity>("Data not null " + result.Message, result.Data), "Ba�ar�yla d�nd�rme sa�land� data null de�il", hateoas, pagination));
            }
            else
            {
                return ErrorDataReturn(result.Message, result.Exception);
            }
        }

        public virtual IActionResult ConvertToReturn<TEntity>(TEntity result, IHateoas? hateoas = null, IPagination? pagination = null)
        {
            return result == null ?
                EmptyDataReturn(null, hateoas, pagination) :
                new OkObjectResult(new Response<TEntity>(new SuccessReturnModel<TEntity>("Data not null ", result), "Ba�ar�yla d�nd�rme sa�land� data null de�il", hateoas, pagination));

        }

        public virtual IActionResult ConvertToReturn(bool status, IHateoas? hateoas = null, IPagination? pagination = null)
        {
            return status ?
                new OkObjectResult(new Response("Ok", hateoas, pagination)) :
                new BadRequestObjectResult(new Response("Error", hateoas, pagination));
        }
    }



    abstract public class AbstractService<TEntity> : AbstractService
        where TEntity : class, IEntity, new()
    {
        internal readonly IRepository<TEntity> repository;
        internal readonly IMapper mapper;
        internal readonly IHateoas hateoas;
        internal readonly IConfiguration configuration;
        internal readonly IHttpContextAccessor httpContextAccessor;
        public AbstractService(IRepository<TEntity> repository, IMapper mapper, IHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.hateoas = hateoas;
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        internal async Task<IReturnModel<GetTokenResponseDTO>> GenerateTokenWithSingIn(string Email, string Status)
        {
            DateTime createTime = DateTime.UtcNow;
            DateTime deleteTime = DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["CookieSettings:ExpireTimeSpan"]));
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(configuration["JwtSettings:IssuerSigningKey"] ?? throw new ArgumentNullException());
            List<Claim> claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role, Status)
            };
            ClaimsIdentity identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
                );
            HttpContext? context = httpContextAccessor.HttpContext;
            if (context != null)
            {
                await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                JwtSecurityToken tokenOptions = new JwtSecurityToken(
                issuer: configuration["JwtSettings:ValidIssuer"],
                audience: configuration["JwtSettings:ValidAudience"],
                claims: claims,
                expires: deleteTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );
                return new SuccessReturnModel<GetTokenResponseDTO>(new GetTokenResponseDTO()
                {
                    Email = Email,
                    Status = Status,
                    Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                    TokenCreateTime = createTime,
                    TokenDeleteTime = deleteTime
                });
            }
            return new ErrorReturnModel<GetTokenResponseDTO>(new GetTokenResponseDTO()
            {
                Email = Email,
                Status = Status,
            });
        }


        internal async Task<bool> Logout()
        {
            HttpContext? context = httpContextAccessor.HttpContext;
            if (context != null)
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return true;
            }
            return false;
        }


    }
    abstract public class AbstractService<TEntity, Response> : AbstractService<TEntity>, IService<Response>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper, IHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, hateoas, configuration, httpContextAccessor) { }
        public virtual IActionResult GetAll()
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.GetAll();
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> GetAllAsync()
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.GetAllAsync();
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }
    }
    abstract public class AbstractService<TEntity, Response, AddRequest> : AbstractService<TEntity, Response>, IService<Response, AddRequest>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
        where AddRequest : class, IAddDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper, IHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, hateoas, configuration, httpContextAccessor) { }

        public virtual IActionResult Add(AddRequest entity)
        {
            IReturnModel<TEntity> result = repository.Add(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual IActionResult Add(IEnumerable<AddRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.Add(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> AddAsync(AddRequest entity)
        {
            IReturnModel<TEntity> result = await repository.AddAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> AddAsync(IEnumerable<AddRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.AddAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual IActionResult Delete(Guid entity)
        {
            IReturnModel<TEntity> result = repository.Get(e => e.Id == entity);
            if(result.Status && result.Data != null) 
            {
                TEntity data = result.Data;
                data.IsDeleted = true;
                return ConvertToReturn<Response, TEntity>(repository.Update(data), mapper, hateoas);
            }
            else
            {
                return ReturnEmptyError<Response>();
            }
        }

        public virtual IActionResult Delete(IEnumerable<Guid> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.GetAll(e => entity.Any(x => x == e.Id));
            if (result.Status && result.Data != null)
            {
                IEnumerable<TEntity> data = result.Data;
                data = data.ChangeAll(e => e.IsDeleted = true);
                return ConvertToReturn<Response, TEntity>(repository.Update(data), mapper, hateoas);
            }
            else
            {
                return ReturnEmptyError<Response>();
            }
        }

        public virtual async Task<IActionResult> DeleteAsync(Guid entity)
        {
            IReturnModel<TEntity> result = await repository.GetAsync(e => e.Id == entity);
            if (result.Status && result.Data != null)
            {
                TEntity data = result.Data;
                data.IsDeleted = true;
                return ConvertToReturn<Response, TEntity>(await repository.UpdateAsync(data), mapper, hateoas);
            }
            else
            {
                return ReturnEmptyError<Response>();
            }
        }

        public virtual async Task<IActionResult> DeleteAsync(IEnumerable<Guid> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.GetAllAsync(e => entity.Any(x => x == e.Id));
            if (result.Status && result.Data != null)
            {
                IEnumerable<TEntity> data = result.Data;
                data = data.ChangeAll(e => e.IsDeleted = true);
                return ConvertToReturn<Response, TEntity>(await repository.UpdateAsync(data), mapper, hateoas);
            }
            else
            {
                return ReturnEmptyError<Response>();
            }
        }
    }

    abstract public class AbstractService<TEntity, Response, AddRequest, UpdateRequest> : AbstractService<TEntity, Response, AddRequest>, IService<Response, AddRequest, UpdateRequest>
        where TEntity : class, IEntity, new()
        where Response : class, IGetDTO
        where AddRequest : class, IAddDTO
        where UpdateRequest : class, IUpdateDTO
    {
        public AbstractService(IRepository<TEntity> repository, IMapper mapper, IHateoas hateoas, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(repository, mapper, hateoas, configuration, httpContextAccessor) { }

        public virtual IActionResult Update(UpdateRequest entity)
        {
            IReturnModel<TEntity> result = repository.Update(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual IActionResult Update(IEnumerable<UpdateRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = repository.Update(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> UpdateAsync(UpdateRequest entity)
        {
            IReturnModel<TEntity> result = await repository.UpdateAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }

        public virtual async Task<IActionResult> UpdateAsync(IEnumerable<UpdateRequest> entity)
        {
            IReturnModel<IEnumerable<TEntity>> result = await repository.UpdateAsync(entity.ConvertToEntityCustom<TEntity>(mapper));
            return ConvertToReturn<Response, TEntity>(result, mapper, hateoas);
        }
    }


}









