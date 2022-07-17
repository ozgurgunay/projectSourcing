using ESourcing.Core.Repositories;
using ESourcing.UI.Clients;
using ESourcing.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.UI.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ProductClient _productClient;
        private readonly AuctionClient _auctionClient;

        public AuctionController(IUserRepository userRepository, ProductClient productClient, AuctionClient auctionClient)
        {
            _userRepository = userRepository;
            _productClient = productClient;
            _auctionClient = auctionClient;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //TODO:Product GetAll

            var productList = await _productClient.GetProducts();
            if (productList.IsSuccess)
                ViewBag.ProductList = productList.Data;


            var userList = await _userRepository.GetAllAsync();
            ViewBag.UserList = userList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(AuctionViewModel model)
        {
            return View(model);
        }

        public IActionResult Detail()
        {

            return View();
        }
    }
}
