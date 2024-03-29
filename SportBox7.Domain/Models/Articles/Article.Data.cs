﻿using SportBox7.Domain.Common;
using SportBox7.Domain.Models.Articles.Enums;
using SportBox7.Domain.Models.Categories;
using SportBox7.Domain.Models.Sources;
using System;
using System.Collections.Generic;
namespace SportBox7.Domain.Models.Articles
{
    internal class ArticleData : IInitialData
    {
        public Type EntityType => typeof(Article);

        public IEnumerable<object> GetData()
        {
            Category footballBG = new Category("Футбол БГ", "FootballBG");
            Category footballWorld = new Category("Футбол свят", "FootBall");
            Category volleyball = new Category("Волейбол", "Volleyball");
            Category basketball = new Category("Баскетбол", "Basketball");
            Category martial = new Category("Бойни", "Martial");

            Category others = new Category("Други", "Others");

            Source source = new Source("sportbox7.com", "https://sportbox7.com", "https://sportbox7.com/img/core-img/logoSmall.jpg");

            List<Article> articles = new List<Article>()
            {
                new Article("Честит юбилей на Георги Денев", "Днес 70-и юбилей празнува знаменитият български футболист Георги Денев. Бившият национал е роден на 18 април 1950 г. в Ловеч, а кариерата му стартира в местния Кърпачев. През сезон 1968/69 играе за Спартак (Плевен), а след това преминава в ЦСКА. За \"армейците\" играе цяло десетилетие, като записва 237 мача и 78 гола за първенство, пет пъти печели шампионската титла и още три пъти Купата на България. В края на кариерата си излиза в чужбина и последователно облича екипите на Етникос (42 мача, 18 гола) и Арис (Лимасол, 47 мача, 16 гола).За националния отбор Денев дебютира през 1970 г.и изиграва 49 мача, в които се разписва десет пъти.Участник на световното първенство във ФРГ през 1974 - а.Българският футболен съюз честити празника на Георги Денев и му желае здраве, късмет и дълголетие!", "Честит юбилей на Георги Денев","https://bfunion.bg/uploads/2020-04-18/size1/GDenev.png", "https://bfunion.bg/archive/2020/4/46795/0", "test Meta Description", "test meta keywords", footballBG , ArticleType.PeriodicArticle, new DateTime(2020, 5, 11), source),

                new Article("Честит рожден ден на Георги Терзиев", "Днес 28 години навършва българският национал Георги Терзиев. Защитникът е роден на 18 април 1992 г. в Сливен, а футболната му кариера започва от школата на едноименния местен клуб. Дебюта си в професионалния футбол Терзиев прави с екипа на Нафтекс на едва 15-годишна възраст, а между 2009-а и 2013-а играе за другия бургаски тим - Черноморец (79 мача, 4 гола). Следва трансфер в Лудогорец, за който до момента бранителят има 143 мача и 5 попадения във всички турнири. Шесткратен шампион на страната, носител на Купата на България, трикратен победител в турнира за Суперкупата. През пролетта на сезон 2016/17 Терзиев играе под наем в хърватския гранд Хайдук (Сплит), записвайки 8 мача за първенство. За националния отбор защитникът дебютира на 7 октомври 2011 г.при загубата от Украйна в приятелски мач, а към днешна дата има 14 изиграни срещи за \"лъвовете\".Българският футболен съюз честити празника на Георги Терзиев и му желае здраве и още много футболни успехи!", "Честит рожден ден на Георги Терзиев","https://bfunion.bg/uploads/2020-04-18/size1/GTerziev.png", "https://bfunion.bg/archive/2020/4/46794/0", "test Meta Description", "test meta keywords", footballWorld, ArticleType.PeriodicArticle, new DateTime(1978, 6, 18), source),

                new Article("Честит рожден ден на Кирил Домусчиев", "Днес 51 години навършва членът на Изпълнителния комитет на Българския футболен съюз Кирил Домусчиев. Собственикът на футболен клуб Лудогорец е роден на 18 април 1969 г. в София. Магистър по Индустриален мениджмънт и маркетинг от Техническия университет, основател на „Напредък Холдинг” АД (чрез „Кимаго” ООД), председател на Надзорния съвет на “Биовет” АД; изпълнителен директор на “Хювефарма” АД. Собственик на 50 % of “Адванс Пропъртис” ООД. Член на Борда на Директорите на “Huvepharma” N.V., Белгия, член на Борда на Директорите на “Huvepharma” Inc., САЩ.  Председател на Борда на Директорите на “Кей Джи Маритайм Шипинг” АД, председател на Борда на Директорите на “ Кей Джи Маритайм Партнърс” АД. Главен акционер в „Параходство Български Морски Флот” АД, председател на Надзорния съвет на „Параходство БМФ” АД. Председател на Конфедерацията на работодателите и индустриалците в България. Във футболните среди Кирил Домусчиев е познат като основоположник напроекта \"Лудогорец\", извел разградския клуб доосем шампионски титли и две Купи на България, както и запомнящи се участия в европейските клубни турнири.Българският футболен съюз честити празникана г - н Домусчиев и му желае здраве и късмет!", "Честит рожден ден на Кирил Домусчиев","https://bfunion.bg/uploads/2020-04-18/size1/image_1516897817_19437.jpeg", "https://bfunion.bg/archive/2020/4/46793/0", "test Meta Description", "test meta keywords", volleyball, ArticleType.PeriodicArticle, new DateTime(1993, 8, 12), source),

                new Article("Честит рожден ден на Антон Попов", "Днес 63 години навършва заместник-изпълнителният директор на Българския футболен съюз Антон Попов. Той е роден на 16 април 1957 г. в град Горна Оряховица, завършва НСА \"Васил Левски\" със специалности \"Педагогика\" и \"Футбол\". Бивш Главен секретар в Държавната агенция за младежта и спорта, както и председател на Областния съвет на БФС в Стара Загора. От февруари 2014 г. е на поста заместник-изпълнителен директор на БФС. Ръководството и служителите на Българския футболен съюз желаят на Антон Поповздравеи успехи както в професионален, така и в личен план!", "Честит рожден ден на Антон Попов","https://bfunion.bg/uploads/2020-04-16/size1/image_1523877794_10219.jpeg", "https://bfunion.bg/archive/2020/4/46792/0", "test Meta Description", "test meta keywords", basketball, ArticleType.PeriodicArticle, new DateTime(2020, 2, 22), source),


                new Article("Честит рожден ден на Велизар Димитров", "Днес 41 години навършва бившият български национал Велизар Димитров. Атакуващият халф е роден на 13 април 1979 г. в Перник, а футболната си кариера стартира от детско-юношеската школа на местния Миньор. За родния си клуб изиграва 28 мача за първенство, в които бележи 6 гола; през 2000-ата за кратко се подвизава в Локомотив (София), а сериозният му пробив идва с фланелката на дупнишкия Марек, за който записва 43 двубоя и 18 попадения. Добрите изяви му осигуряват трансфер в ЦСКА, където бързо се налага като основен футболист. В рамките на шест сезона изиграва 158 мача за \"червените\" във всички турнири, в които се разписва 45 пъти, на три пъти става шампион на страната и веднъж печели Купата на България. През лятото на 2008-а подписва с украинския Металург (Донецк), където завършва кариерата си, добавяйки 108 мача и 18 гола за първенство към визитката си. За националния отбор на България Велизар Димитров дебютира през 2004 - а и общо изиграва 31 мача, в които вкарва 4 гола.Участник на европейското първенство в Португалия през 2004 - а. След края на състезателната си кариера работи като скаут за Металург(Донецк) и ЦСКА - София. Българският футболен съюз честити рождения ден на Велизар Димитров и му желае късмет и много бъдещи успехи!", "Честит рожден ден на Велизар Димитров","https://bfunion.bg/uploads/2020-04-13/size1/VDimitrov.png", "https://bfunion.bg/archive/2020/4/46787/0", "test Meta Description", "test meta keywords", martial, ArticleType.PeriodicArticle, new DateTime(2020, 3, 18), source),

                new Article("Любо Ганев свиква конферентен УС", "Любо Ганев свиква следващата седмица първо заседание на управителния съвет на волейболната федерация след проведеното на 13 март общо събрание. Новоизбраните членове на ръководството трябва да решат как ще завършат националните първенства.", "Любо Ганев свиква конферентен УС","https://www.volleyball.bg/media/k2/items/cache/ad599b9fcc57857fe9e8210e5336a36d_XL.jpg", "https://www.volleyball.bg/news/item/6196", "test Meta Description", "test meta keywords", others, ArticleType.PeriodicArticle, new DateTime(2021, 1, 18), source)
            };

            return articles;
        }
    }
}
