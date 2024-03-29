﻿using Microsoft.AspNetCore.Mvc;
using PetStore.Services;
using PetStore.Services.Models.Pet;
using PetStore.Web.Models;
using PetStore.Web.Models.Pet;
using System.Collections.Generic;

namespace PetStore.Web.Controllers
{
   
    public class PetsController : Controller
    {

        private readonly IPetService pets;

        public PetsController(IPetService pets)
        {
            this.pets = pets;
        }


        //  /pets/all
        public IActionResult All(int page = 1)
        {
            var allPets = this.pets.All(page);
            var totalPets = this.pets.Total();

            var model = new AllPetsViewModel
            {
                Pets = allPets,
                Total = totalPets,
                CurrentPage = page
            };

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var pet = this.pets.Details(id);

            if(pet == null)
            {
                return NotFound();
            }

            return View(pet);
        } 
        
        public IActionResult ConfirmDelete(int id)
        {
            var deleted = this.pets.Delete(id);

            if (!deleted)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
