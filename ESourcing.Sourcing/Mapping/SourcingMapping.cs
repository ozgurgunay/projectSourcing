using AutoMapper;
using ESourcing.Sourcing.Entities;
using EventBusRabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Sourcing.Mapping
{
    public class SourcingMapping : Profile //: Profile //bu profile automapper paketinde var nugettan yükleyince aç
    {
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();

        }

    }
}
