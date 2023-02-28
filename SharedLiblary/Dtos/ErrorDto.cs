using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLiblary.Dtos
{
    public class ErrorDto
    {
        public List<String> Errors { get; private set; }

        public ErrorDto()
        {
            Errors = new List<string>();
        }

        public bool IsShow { get; private set; } /*  Bezen ele olcaq ki, clientin anlayacagi yox proqramcinin alayacagi xetalar bas verir. o zaman biz bunu false olaraq qeyd edeceyik ki, o xetalari client gormesin. Clientin anlayacagi xeta olacaqsa eger true olaraq qeyd edib teqdim edeceyik 
           
        Yeni ele xeta geler ki, deyerik he bunu istifadeciye goster frontend, bezen ele xeta olar ki app daxilinde proqramcinin basa duseceyi xeta geler, o zaman false olacaq */



        public ErrorDto(string error, bool isShow) /* Yene xeta meydana gele biler. Yuxaridaki Errors-a burdaki yaranan xetani elave edirik.*/
        {
            Errors.Add(error);
            isShow = true;
        }
        public ErrorDto(List<string> errors, bool isShow)  /*Birden artiq xeta emele gele biler burada*/
        {
            Errors = errors;
            IsShow = isShow;
        }
    }
}
