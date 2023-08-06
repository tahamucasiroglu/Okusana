# Proje Notlarý


fluent validation attribute oluyor



blog ve diðerlerindeki dönüþlerde sayfalama ekle. 
Çoklu sýnýf yapýsýna bak yani actionlara yanlarýna PagenatiopnModel gibi ekleme olur mu bak


basede authorize ekledin onun configlerini ayarla test et sonra sikir git FE yap arayüz yok elde

### Notlar

* dotnet ef migrations add 1_test_mig -> migleme
* dotnet ef database update -> push db
* <del>min pool size 0 olmamalý hata veriyor nedene bakarsýn</del>
* IsRequired lar galiba zaten true onlarý kladýr olmadý þimdilik garanti için kalsýn

### Yapýlacaklar

* entitler doldurulacaklar.
* entitlere configleri hazýrla ve index hasdata totable gibi þeyleri detaylýca hazýrla
* <del> Idler guid oalcak </del>
* kategory - user - userstatus - blog - ekle ek olarak týklama sayýsý fantazi  istersek apriori algosu filan eklenebilir.
* az öz fonsiyon olmalý
* admin için post ekleme sayfasý
* mvvm kullanmaya çalýþ
* postgresql vs sql server farklarýný araþtýr
* dokðmanlarda ef core ile ilgili araþtýrmalarý yap
* gençayýn videolarý bak
* JWT kýsmýný düþün
* DB için kontrolleri yap ve sürekli geliþtirme hazýrla orasý en dertli yer
* fluent validation yap attributeleri turkcell kullanmýyor oraya uyum saðlamalýsýn. Attribute ikna ettin ama fluent olmalý kullanrak yapman lazým ben mimar deðilim. Henüz :D
* react js dalýnacak fakat önce BE sonra komple FE girilecek ve tükürülen yalanacak 
* týklamalarda istatistik kullanýlabbilir þu ilden þu yaþtan þu kadar giriþ gibi sonra olur bu
* blog eklemede resim ekleme, belirli tarihte ekleme, yazý tipi ayarlamalarý, gibi wordpress þeyleri yap hatta wordpress ile yapýlan blog sitesi gibi admin editör ve kullanýcý kýsmý yap.
* bloglarda IsRequired zaten true muþ onlara bak sonarcube de hata vermese bile git test et olmadý kaldýr gereksiz kod
* postgresql in içinde bir sürü farklýlýklar var sql server a göre bak sonra ona göre optimize et 
* bloglarda publicationDate için kontrol ekle iþte vakti gelince yayýnlasýn ama burasý nasýl olacak hangfire yapar mý bilemedinm.
* db de userid gibi þeyleri ef kendi ayarlýyor onlarý ilerde kaldýr þimdi karýþacak kalsýn
* yorumlarýda recursive yap yoruma yorum yapsýnlar
* bazý yerlerde view eklebilir
* BlogTag için ol ara sistemde Core lar ile çalýþýlmasý lazým bakýn
* servislere sonradan mail servisi eklemeyi dene
* CQRS yapýsý eklemeyi deneyebilrisin
* <del> özel IServicelerde IActionresult dön kalanlarýný oradan kullan. </del>
* <del> servisler httpstatus dönecek </del>

### sorulacaklar
* validationdaki Isrequired içindeki isrequired durmalý mý amacý config te require true dan false olursa exception fýrlatýp hatýrlatmak
* abstractservice ve abstractrepositorylerdeki parçalamalar mantýklý mý 
* take hatasý sebebi nedir
* user tablosunda emaili de key yaparak herkesin farklý email e sahip olmasý garantilenecek ama baseden gelen Id sonrasý hata veriyor. birleþtirme yolu var mý
* bu jwt tokený program.cs içinde tanýmladýktan sonra oradaki ayarlarla nasýl kullanacaðýz nette süzgün bir sonuç bulamadým herkes iki kere jwt token üretici yapmýþ






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
        public IActionResult EmptyDataReturn<TCheck, TEntity>(string? Message = null, IHateoas? IHateoas = null, IPagination? pagination = null) => new OkObjectResult(new Response<TCheck>(new SuccessReturnModel<TCheck>("Data is null " + Message), "Baþarýyla döndürme saðlandý fakat data null", IHateoas, pagination));
        public IActionResult EmptyDataReturn(string? Message = null, IHateoas? IHateoas = null, IPagination? pagination = null) => new OkObjectResult(new Response( "Baþarýyla döndürme saðlandý fakat data null <->" + Message, IHateoas, pagination));

        public IActionResult ErrorDataReturn<TCheck>(string? Message = null, Exception? exception = null) => new BadRequestObjectResult(new Response<TCheck>(new ErrorReturnModel<TCheck>(Message, exception)));
        public IActionResult ErrorDataReturn(string? Message = null, Exception? exception = null) => new BadRequestObjectResult(new Response(Message + exception?.Message));

        public IActionResult NotFoundReturn<TCheck>(string? Message = null, Exception? exception = null) => new NotFoundObjectResult(new Response<TCheck>(new ErrorReturnModel<TCheck>(Message, exception)));

        public virtual IActionResult ReturnEmptyError<T>(string? Message = null) => new BadRequestObjectResult(new ErrorReturnModel<T>(Message));
        /// <summary>
        /// Tüm servis dönüþlerini kontrol etmek ve kolayca dönüþtürmek için kullanýlan yardýmcý bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüþtürülecek DTO tipini belirten IDto türetilmiþ sýnýf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiþ sýnýf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüþtürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüþümünde kullanýlacak IMapper nesnesi.</param> 
        /// <returns>Dönüþtürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IActionResult ConvertToReturn<TCheck, TEntity>(IReturnModel<TEntity> result, IMapper mapper, IHateoas? hateoas = null, IPagination? pagination = null)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null ?
                    EmptyDataReturn<TCheck, TEntity>(result.Message, hateoas, pagination) :
                    new OkObjectResult(new Response<TCheck>(new SuccessReturnModel<TCheck>("Data not null " + result.Message, result.Data.ConvertToDtoCustom<TCheck>(mapper)), "Baþarýyla döndürme saðlandý data null deðil", hateoas, pagination));
            }
            else
            {
                return ErrorDataReturn<TCheck>(result.Message, result.Exception);
            }
        }
        /// <summary>
        /// Tüm servis dönüþlerini kontrol etmek ve kolayca dönüþtürmek için kullanýlan yardýmcý bir method.
        /// </summary>
        /// <typeparam name="TCheck">Dönüþtürülecek DTO tipini belirten IDto türetilmiþ sýnýf.</typeparam>
        /// <typeparam name="Entity">Db'den dönen verinin tipini belirten IEntity türetilmiþ sýnýf.</typeparam>
        /// <param name="result">Db'den gelen ve DTO'ya dönüþtürülecek veriyi temsil eden IReturnModel nesnesi.</param>
        /// <param name="mapper">DTO dönüþümünde kullanýlacak IMapper nesnesi.</param> 
        /// <returns>Dönüþtürülen sonucu temsil eden IReturnModel nesnesi.</returns>
        public virtual IActionResult ConvertToReturn<TCheck, TEntity>(IReturnModel<IEnumerable<TEntity>> result, IMapper mapper, IHateoas? hateoas = null, IPagination? pagination = null)
            where TCheck : class, IGetDTO
            where TEntity : class, IEntity, new()
        {
            if (result.Status)
            {
                return result.Data == null ?
                    EmptyDataReturn<IEnumerable<TCheck>, TEntity>(result.Message, hateoas, pagination) :
                    new OkObjectResult(new Response<IEnumerable<TCheck>>(new SuccessReturnModel<IEnumerable<TCheck>>("Data not null " + result.Message, result.Data.ConvertToDtoCustom<TCheck>(mapper)), "Baþarýyla döndürme saðlandý data null deðil", hateoas, pagination));
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
                    new OkObjectResult(new Response<TEntity>(new SuccessReturnModel<TEntity>("Data not null " + result.Message, result.Data), "Baþarýyla döndürme saðlandý data null deðil", hateoas, pagination));
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
                new OkObjectResult(new Response<TEntity>(new SuccessReturnModel<TEntity>("Data not null ", result), "Baþarýyla döndürme saðlandý data null deðil", hateoas, pagination));

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









