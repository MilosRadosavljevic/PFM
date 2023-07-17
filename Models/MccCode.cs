using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PFM.Models
{
    public enum MccCode
    {
        [Description("Telecommunication service including local and long distance calls, credit card calls, calls through use of magneticstrip reading telephones and fax services")]
        MCC1 = 4814,

        [Description("VisaPhone")]
        MCC2 = 4815,

        [Description("Telegraph services")]
        MCC3 = 4821,

        [Description("Money Orders - Wire Transfer")]
        MCC4 = 4829,

        [Description("Cable and other pay television (previously Cable Services)")]
        MCC5 = 4899,

        [Description("Electric, Gas, Sanitary and Water Utilities")]
        MCC6 = 4900,

        [Description("Motor vehicle supplies and new parts")]
        MCC7 = 5013,

        [Description("Office and Commercial Furniture")]
        MCC8 = 5021,

        [Description("Construction Materials, Not Elsewhere Classified")]
        MCC9 = 5039,

        [Description("Office, Photographic, Photocopy, and Microfilm Equipment")]
        MCC10 = 5044,

        [Description("Computers, Computer Peripheral Equipment, Software")]
        MCC11 = 5045,

        [Description("Commercial Equipment, Not Elsewhere Classified")]
        MCC12 = 5046,

        [Description("Medical, Dental Ophthalmic, Hospital Equipment and Supplies")]
        MCC13 = 5047,

        [Description("Metal Service Centers and Offices")]
        MCC14 = 5051,

        [Description("Electrical Parts and Equipment")]
        MCC15 = 5065,

        [Description("Hardware Equipment and Supplies")]
        MCC16 = 5072,

        [Description("Plumbing and Heating Equipment and Supplies")]
        MCC17 = 5074,

        [Description("Industrial Supplies, Not Elsewhere Classified")]
        MCC18 = 5085,

        [Description("Precious Stones and Metals, Watches and Jewelry")]
        MCC19 = 5094,

        [Description("Durable Goods, Not Elsewhere Classified")]
        MCC20 = 5099,

        [Description("Stationery, Office Supplies, Printing, and Writing Paper")]
        MCC21 = 5111,

        [Description("Drugs, Drug Proprietors, and Druggist’s Sundries")]
        MCC22 = 5122,

        [Description("Piece Goods, Notions, and Other Dry Goods")]
        MCC23 = 5131,

        [Description("Men’s Women’s and Children’s Uniforms and Commercial Clothing")]
        MCC24 = 5137,

        [Description("Commercial Footwear")]
        MCC25 = 5139,

        [Description("Chemicals and Allied Products, Not Elsewhere Classified")]
        MCC26 = 5169,

        [Description("Petroleum and Petroleum Products")]
        MCC27 = 5172,

        [Description("Books, Periodicals, and Newspapers")]
        MCC28 = 5192,

        [Description("Florists’ Supplies, Nursery Stock and Flowers")]
        MCC29 = 5193,

        [Description("Paints, Varnishes, and Supplies")]
        MCC30 = 5198,

        [Description("Non-durable Goods, Not Elsewhere Classified")]
        MCC31 = 5199,

        [Description("Home Supply Warehouse Stores")]
        MCC32 = 5200,

        [Description("Lumber and Building Materials Stores")]
        MCC33 = 5211,

        [Description("Glass Stores")]
        MCC34 = 5231,

        [Description("Paint and Wallpaper Stores")]
        MCC35 = 5231,

        [Description("Wallpaper Stores")]
        MCC36 = 5231,

        [Description("Hardware Stores")]
        MCC37 = 5251,

        [Description("Nurseries – Lawn and Garden Supply Store")]
        MCC38 = 5261,

        [Description("Mobile Home Dealers")]
        MCC39 = 5271,

        [Description("Wholesale Clubs")]
        MCC40 = 5300,

        [Description("Duty Free Store")]
        MCC41 = 5309,

        [Description("Discount Stores")]
        MCC42 = 5310,

        [Description("Department Stores")]
        MCC43 = 5311,

        [Description("Variety Stores")]
        MCC44 = 5331,

        [Description("Misc. General Merchandise")]
        MCC45 = 5399,

        [Description("Grocery Stores")]
        MCC46 = 5411,

        [Description("Supermarkets")]
        MCC47 = 5411,

        [Description("Freezer and Locker Meat Provisioners")]
        MCC48 = 5422,

        [Description("Meat Provisioners – Freezer and Locker")]
        MCC49 = 5422,

        [Description("Candy Stores")]
        MCC50 = 5441,

        [Description("Confectionery Stores")]
        MCC51 = 5441,

        [Description("Nut Stores")]
        MCC52 = 5441,

        [Description("Dairy Products Stores")]
        MCC53 = 5451,

        [Description("Bakeries")]
        MCC54 = 5462,

        [Description("Misc. Food Stores – Convenience Stores and Specialty Markets")]
        MCC55 = 5499,

        [Description("Car and Truck Dealers (New and Used) Sales, Service, Repairs, Parts, and Leasing")]
        MCC56 = 5511,

        [Description("Automobile and Truck Dealers (Used Only)")]
        MCC57 = 5521,

        [Description("Automobile Supply Stores")]
        MCC58 = 5531,

        [Description("Automotive Tire Stores")]
        MCC59 = 5532,

        [Description("Automotive Parts, Accessories Stores")]
        MCC60 = 5533,

        [Description("Service Stations ( with or without ancillary services)")]
        MCC61 = 5541,

        [Description("Automated Fuel Dispensers")]
        MCC62 = 5542,

        [Description("Boat Dealers")]
        MCC63 = 5551,

        [Description("Recreational and Utility Trailers, Camp Dealers")]
        MCC64 = 5561,

        [Description("Motorcycle Dealers")]
        MCC65 = 5571,

        [Description("Motor Home Dealers")]
        MCC66 = 5592,

        [Description("Snowmobile Dealers")]
        MCC67 = 5598,

        [Description("Men’s and Boy’s Clothing and Accessories Stores")]
        MCC68 = 5611,

        [Description("Women’s Ready - to - Wear Stores")]
        MCC69 = 5621,

        [Description("Women’s Accessory and Specialty Shops")]
        MCC70 = 5631,

        [Description("Children’s and Infant’s Wear Stores")]
        MCC71 = 5641,

        [Description("Family Clothing Stores")]
        MCC72 = 5651,

        [Description("Sports Apparel, Riding Apparel Stores")]
        MCC73 = 5655,

        [Description("Shoe Stores")]
        MCC74 = 5661,

        [Description("Furriers and Fur Shops")]
        MCC75 = 5681,

        [Description("Men’s and Women’s Clothing Stores")]
        MCC76 = 5691,

        [Description("Tailors, Seamstress, Mending, and Alterations")]
        MCC77 = 5697,

        [Description("Wig and Toupee Stores")]
        MCC78 = 5698,

        [Description("Miscellaneous Apparel and Accessory Shops")]
        MCC79 = 5699,

        [Description("Furniture, Home Furnishings, and Equipment Stores, Except Appliances")]
        MCC80 = 5712,

        [Description("Floor Covering Stores")]
        MCC81 = 5713,

        [Description("Drapery, Window Covering and Upholstery Stores")]
        MCC82 = 5714,

        [Description("Fireplace, Fireplace Screens, and Accessories Stores")]
        MCC83 = 5718,

        [Description("Miscellaneous Home Furnishing Specialty Stores")]
        MCC84 = 5719,

        [Description("Household Appliance Stores")]
        MCC85 = 5722,

        [Description("Electronic Sales")]
        MCC86 = 5732,

        [Description("Music Stores, Musical Instruments, Piano Sheet Music")]
        MCC87 = 5733,

        [Description("Computer Software Stores")]
        MCC88 = 5734,

        [Description("Record Shops")]
        MCC89 = 5735,

        [Description("Caterers")]
        MCC90 = 5811,

        [Description("Eating places and Restaurants")]
        MCC91 = 5812,

        [Description("Drinking Places (Alcoholic Beverages), Bars, Taverns, Cocktail lounges, Nightclubs and Discotheques")]
        MCC92 = 5813,

        [Description("Fast Food Restaurants")]
        MCC93 = 5814,

        [Description("Drug Stores and Pharmacies")]
        MCC94 = 5912,

        [Description("Package Stores - Beer, Wine, and Liquor")]
        MCC95 = 5921,

        [Description("Used Merchandise and Secondhand Stores")]
        MCC96 = 5931,

        [Description("Antique Shops - Sales, Repairs, and Restoration Services")]
        MCC97 = 5832,

        [Description("Pawn Shops and Salvage Yards")]
        MCC98 = 5933,

        [Description("Wrecking and Salvage Yards")]
        MCC99 = 5935,

        [Description("Antique Reproductions")]
        MCC100 = 5937,

        [Description("Bicycle Shops - Sales and Service")]
        MCC101 = 5940,

        [Description("Sporting Goods Stores")]
        MCC102 = 5941,

        [Description("Book Stores")]
        MCC103 = 5942,

        [Description("Stationery Stores, Office and School Supply Stores")]
        MCC104 = 5943,

        [Description("Watch, Clock, Jewelry, and Silverware Stores")]
        MCC105 = 5944,

        [Description("Hobby, Toy, and Game Shops")]
        MCC106 = 5945,

        [Description("Camera and Photographic Supply Stores")]
        MCC107 = 5946,

        [Description("Card Shops, Gift, Novelty, and Souvenir Shops")]
        MCC108 = 5947,

        [Description("Leather Foods Stores")]
        MCC109 = 5948,

        [Description("Sewing, Needle, Fabric, and Price Goods Stores")]
        MCC110 = 5949,

        [Description("Glassware/Crystal Stores")]
        MCC111 = 5950,

        [Description("Direct Marketing - Insurance Service")]
        MCC112 = 5960,

        [Description("Mail Order Houses Including Catalog Order Stores, Book/Record Clubs (No longer permitted for .S. original presentments)")]
        MCC113 = 5961,

        [Description("Direct Marketing - Travel Related Arrangements Services")]
        MCC114 = 5962,

        [Description("Door - to - Door Sales")]
        MCC115 = 5963,

        [Description("Direct Marketing - Catalog Merchant")]
        MCC116 = 5964,

        [Description("Direct Marketing - Catalog and Catalog and Retail Merchant Direct Marketing - Outbound Telemarketing Merchant")]
        MCC117 = 5965,

        [Description("Direct Marketing -Inbound Teleservices Merchant")]
        MCC118 = 5967,

        [Description("Direct Marketing - Continuity/Subscription Merchant")]
        MCC119 = 5968,

        [Description("Direct Marketing - Not Elsewhere Classified")]
        MCC120 = 5969,

        [Description("Artist’s Supply and Craft Shops")]
        MCC121 = 5970,

        [Description("Art Dealers and Galleries")]
        MCC122 = 5971,

        [Description("Stamp and Coin Stores - Philatelic and Numismatic Supplies")]
        MCC123 = 5972,

        [Description("Religious Goods Stores")]
        MCC124 = 5973,

        [Description("Hearing Aids - Sales, Service, and Supply Stores")]
        MCC125 = 5975,

        [Description("Orthopedic Goods Prosthetic Devices")]
        MCC126 = 5976,

        [Description("Cosmetic Stores")]
        MCC127 = 5977,

        [Description("Typewriter Stores - Sales, Rental, Service")]
        MCC128 = 5978,

        [Description("Fuel - Fuel Oil, Wood, Coal, Liquefied Petroleum")]
        MCC129 = 5983,

        [Description("Florists")]
        MCC130 = 5992,

        [Description("Cigar Stores and Stands")]
        MCC131 = 5993,

        [Description("News Dealers and Newsstands")]
        MCC132 = 5994,

        [Description("Pet Shops, Pet Foods, and Supplies Stores")]
        MCC133 = 5995,

        [Description("Swimming Pools - Sales, Service, and Supplies")]
        MCC134 = 5996,

        [Description("Electric Razor Stores - Sales and Service")]
        MCC135 = 5997,

        [Description("Tent and Awning Shops")]
        MCC136 = 5998,

        [Description("Miscellaneous and Specialty Retail Stores")]
        MCC137 = 5999,

        [Description("Financial Institutions - Manual Cash Disbursements")]
        MCC138 = 6010,

        [Description("Financial Institutions - Manual Cash Disbursements")]
        MCC139 = 6011,

        [Description("Financial Institutions - Merchandise and Services")]
        MCC140 = 6012,

        [Description("Non - Financial Institutions - Foreign Currency, Money Orders (not wire transfer) and Travelers Cheques")]
        MCC141 = 6051,

        [Description("Security Brokers/Dealers")]
        MCC142 = 6211,

        [Description("Insurance Sales, Underwriting, and Premiums")]
        MCC143 = 6300,

        [Description("Insurance Premiums, (no longer valid for first presentment work)")]
        MCC144 = 6381,

        [Description("Insurance, Not Elsewhere Classified ( no longer valid for first presentment work)")]
        MCC145 = 6399,

        [Description("Lodging - Hotels, Motels, Resorts, Central Reservation Services (not elsewhere classified)")]
        MCC146 = 7011,

        [Description("Timeshares")]
        MCC147 = 7012,

        [Description("Sporting and Recreational Camps")]
        MCC148 = 7032,

        [Description("Trailer Parks and Camp Grounds")]
        MCC149 = 7033,

        [Description("Laundry, Cleaning, and Garment Services")]
        MCC150 = 7210,

        [Description("Laundry - Family and Commercial")]
        MCC151 = 7211,

        [Description("Dry Cleaners")]
        MCC152 = 7216,

        [Description("Carpet and Upholstery Cleaning")]
        MCC153 = 7217,

        [Description("Photographic Studios")]
        MCC154 = 7221,

        [Description("Barber and Beauty Shops")]
        MCC155 = 7230,

        [Description("Shop Repair Shops and Shoe Shine Parlors, and Hat Cleaning Shops")]
        MCC156 = 7251,

        [Description("Funeral Service and Crematories")]
        MCC157 = 7261,

        [Description("Dating and Escort Services")]
        MCC158 = 7273,

        [Description("Tax Preparation Service")]
        MCC159 = 7276,

        [Description("Counseling Service - Debt, Marriage, Personal")]
        MCC160 = 7277,

        [Description("Buying/Shopping Services, Clubs")]
        MCC161 = 7278,

        [Description("Clothing Rental - Costumes, Formal Wear, Uniforms")]
        MCC162 = 7296,

        [Description("Massage Parlors")]
        MCC163 = 7297,

        [Description("Health and Beauty Shops")]
        MCC164 = 7298,

        [Description("Miscellaneous Personal Services ( not elsewhere classifies)")]
        MCC165 = 7299,

        [Description("Advertising Services")]
        MCC166 = 7311,

        [Description("Consumer Credit Reporting Agencies")]
        MCC167 = 7321,

        [Description("Blueprinting and Photocopying Services")]
        MCC168 = 7332,

        [Description("Commercial Photography, Art and Graphics")]
        MCC169 = 7333,

        [Description("Quick Copy, Reproduction and Blueprinting Services")]
        MCC170 = 7338,

        [Description("Stenographic and Secretarial Support Services")]
        MCC171 = 7339,

        [Description("Disinfecting Services")]
        MCC172 = 7342,

        [Description("Exterminating and Disinfecting Services")]
        MCC173 = 7342,

        [Description("Cleaning and Maintenance, Janitorial Services")]
        MCC174 = 7349,

        [Description("Employment Agencies, Temporary Help Services")]
        MCC175 = 7361,

        [Description("Computer Programming, Integrated Systems Design and Data Processing Services")]
        MCC176 = 7372,

        [Description("Information Retrieval Services")]
        MCC177 = 7375,

        [Description("Computer Maintenance and Repair Services, Not Elsewhere Classified")]
        MCC178 = 7379,

        [Description("Management, Consulting, and Public Relations Services")]
        MCC179 = 7392,

        [Description("Protective and Security Services - Including Armored Cars and Guard Dogs")]
        MCC180 = 7393,

        [Description("Equipment Rental and Leasing Services, Tool Rental, Furniture Rental, and Appliance Rental")]
        MCC181 = 7394,

        [Description("Photofinishing Laboratories, Photo Developing")]
        MCC182 = 7395,

        [Description("Business Services, Not Elsewhere Classified")]
        MCC183 = 7399,

        [Description("Car Rental Companies ( Not Listed Below)")]
        MCC184 = 7512,

        [Description("Truck and Utility Trailer Rentals")]
        MCC185 = 7513,

        [Description("Motor Home and Recreational Vehicle Rentals")]
        MCC186 = 7519,

        [Description("Automobile Parking Lots and Garages")]
        MCC187 = 7523,

        [Description("Automotive Body Repair Shops")]
        MCC188 = 7531,

        [Description("Tire Re - treading and Repair Shops")]
        MCC189 = 7534,

        [Description("Paint Shops - Automotive")]
        MCC190 = 7535,

        [Description("Automotive Service Shops")]
        MCC191 = 7538,

        [Description("Car Washes")]
        MCC192 = 7542,

        [Description("Towing Services")]
        MCC193 = 7549,

        [Description("Radio Repair Shops")]
        MCC194 = 7622,

        [Description("Air Conditioning and Refrigeration Repair Shops")]
        MCC195 = 7623,

        [Description("Electrical And Small Appliance Repair Shops")]
        MCC196 = 7629,

        [Description("Watch, Clock, and Jewelry Repair")]
        MCC197 = 7631,

        [Description("Furniture, Furniture Repair, and Furniture Refinishing")]
        MCC198 = 7641,

        [Description("Welding Repair")]
        MCC199 = 7692,

        [Description("Repair Shops and Related Services - Miscellaneous")]
        MCC200 = 7699,

        [Description("Motion Pictures and Video Tape Production and Distribution")]
        MCC201 = 7829,

        [Description("Motion Picture Theaters")]
        MCC202 = 7832,

        [Description("Video Tape Rental Stores")]
        MCC203 = 7841,

        [Description("Dance Halls, Studios and Schools")]
        MCC204 = 7911,

        [Description("Theatrical Producers (Except Motion Pictures), Ticket Agencies")]
        MCC205 = 7922,

        [Description("Bands. Orchestras, and Miscellaneous Entertainers (Not Elsewhere Classified)")]
        MCC206 = 7929,

        [Description("Billiard and Pool Establishments")]
        MCC207 = 7932,

        [Description("Bowling Alleys")]
        MCC208 = 7933,

        [Description("Commercial Sports, Athletic Fields, Professional Sport Clubs, and Sport Promoters")]
        MCC209 = 7941,

        [Description("Tourist Attractions and Exhibits")]
        MCC210 = 7991,

        [Description("Golf Courses - Public")]
        MCC211 = 7992,

        [Description("Video Amusement Game Supplies")]
        MCC212 = 7993,

        [Description("Video Game Arcades/Establishments")]
        MCC213 = 7994,

        [Description("Betting (including Lottery Tickets, Casino Gaming Chips, Off - track Betting and Wagers)")]
        MCC214 = 7995,

        [Description("Amusement Parks, Carnivals, Circuses, Fortune Tellers")]
        MCC215 = 7996,

        [Description("Membership Clubs (Sports, Recreation, Athletic), Country Clubs, and Private Golf Courses")]
        MCC216 = 7997,

        [Description("Aquariums, Sea - aquariums, Dolphinariums")]
        MCC217 = 7998,

        [Description("Recreation Services (Not Elsewhere Classified)")]
        MCC218 = 7999,

        [Description("Doctors and Physicians (Not Elsewhere Classified)")]
        MCC219 = 8011,

        [Description("Dentists and Orthodontists")]
        MCC220 = 8021,

        [Description("Osteopaths")]
        MCC221 = 8031,

        [Description("Chiropractors")]
        MCC222 = 8041,

        [Description("Optometrists and Ophthalmologists")]
        MCC223 = 8042,

        [Description("Opticians, Opticians Goods and Eyeglasses")]
        MCC224 = 8043,

        [Description("Opticians, Optical Goods, and Eyeglasses (no longer valid for first presentments)")]
        MCC225 = 8044,

        [Description("Podiatrists and Chiropodists")]
        MCC226 = 8049,

        [Description("Nursing and Personal Care Facilities")]
        MCC227 = 8050,

        [Description("Hospitals")]
        MCC228 = 8062,

        [Description("Medical and Dental Laboratories")]
        MCC229 = 8071,

        [Description("Medical Services and Health Practitioners (Not Elsewhere Classified)")]
        MCC230 = 8099,

        [Description("Legal Services and Attorneys")]
        MCC231 = 8111,

        [Description("Elementary and Secondary Schools")]
        MCC232 = 8211,

        [Description("Colleges, Junior Colleges, Universities, and Professional Schools")]
        MCC233 = 8220,

        [Description("Correspondence Schools")]
        MCC234 = 8241,

        [Description("Business and Secretarial Schools")]
        MCC235 = 8244,

        [Description("Vocational Schools and Trade Schools")]
        MCC236 = 8249,

        [Description("Schools and Educational Services (Not Elsewhere Classified)")]
        MCC237 = 8299,

        [Description("Religious Organizations")]
        MCC238 = 8661,

        [Description("Membership Organizations (Not Elsewhere Classified)")]
        MCC239 = 8699,

        [Description("Professional Services (Not Elsewhere Classified)")]
        MCC240 = 8999,

        [Description("Public Administration (Not Elsewhere Classified)")]
        MCC241 = 9199,

        [Description("Foreign Government")]
        MCC242 = 9402,

        [Description("United States Government")]
        MCC243 = 9405,

        [Description("Financing - Manual Cash Disbursements")]
        MCC244 = 9700,

        [Description("Automated Cash Disbursements")]
        MCC245 = 9701,

        [Description("Visa Intra - company Purchases")]
        MCC246 = 9702,

        [Description("GCAS Emergency Services")]
        MCC247 = 9703,

        [Description("Visa - Money Transfer")]
        MCC248 = 9704,

        [Description("GCAS Security Escort")]
        MCC249 = 9705,

        [Description("Visa - Stored Value Load")]
        MCC250 = 9706,

        [Description("GCAS T&E and Remittance Processing")]
        MCC251 = 9707,

        [Description("GCAS Cardholder Inquiry Service")]
        MCC252 = 9708,

        [Description("GCAS Dispute Processing")]
        MCC253 = 9709,

        [Description("GCAS Travel Agency Services")]
        MCC254 = 9710,

        [Description("Visa Money Transfer - On - us Domestic")]
        MCC255 = 9711,

        [Description("Visa Money Transfer - International")]
        MCC256 = 9712,

        [Description("Visa Money Transfer - On - us")]
        MCC257 = 9713,

        [Description("GCAS Acquirer Fraud Alerts")]
        MCC258 = 9714,

        [Description("GCAS Security Message Only")]
        MCC259 = 9715,

        [Description("Stored Value Card Load - General Purpose Reloadable")]
        MCC260 = 9950,

        [Description("Stored Value Card Load - Non - Reloadable")]
        MCC261 = 9951,

        [Description("Mobile Load")]
        MCC262 = 9952,

        [Description("Gift Card and Gift Certificate Issuers")]
        MCC263 = 9953,

        [Description("Card Not Present Merchants")]
        MCC264 = 9999,

    }
}
