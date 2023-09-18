using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace CourseProject;

class Program
{
    // Define a sample data object


    // Function definition
    static int AddNumbers(int a, int b) {
        return a + b;
    }

    PersonClass person = new PersonClass("John", "Doe", 30);
    // This is a single-line comment

    /*
        This is a multi-line comment.
        You can add more lines here.
    */

    static void Main(string[] args)
    {



        /* regex test
        string htmlTest = HtmlInfoParser.HtmlTestInput();
        Dictionary<string, string> dct = HtmlInfoParser.ParseAllInfo(htmlTest);
        foreach (KeyValuePair<string, string> kvp in dct)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
        */
string htmlContent = """

<!DOCTYPE html>
<html id="html" xmlns="http://www.w3.org/1999/xhtml" lang="da" xml:lang="da">

<head>
	<meta http-equiv="X-UA-Compatible" content="IE=edge" />

	<!--googleoff: index-->
	<title>



    Kursusevalueringer


 - Studieinformation</title>
	<meta charset="UTF-8" />

	<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1" />

<meta name="og:description" content="" />
<meta name="keywords" content="" />
<meta name="DTUKeywords" content="" />
<meta name="dtucontenttype" content="ArticleHtml" />
<meta name="pid" content="df2e7462-00cb-403a-aa3e-a7072356f3e1"/>
<meta name="lid" content=""/>
<meta property="og:title" content="


    Kursusevalueringer


 - Studieinformation" />
<meta property="og:type" content="ArticleHtml" />
<meta property="og:url" content="https://studieinformation.dtu.dk/service/NoegletalEkstern?hidecontent=true" />
<meta property="og:image" content="" />
<meta property="og:site_name" content="https://studieinformation.dtu.dk" />
<meta property="twitter:card" content="summary" />
<meta property="twitter:site" content="@dtutweet" />
<meta name="personname" content="" />
<meta name="profiletype" content="" />
<meta name="profiletitle" content="" />
<meta name="profiletitleen" content="" />
<meta name="profileorgunit" content="" />
<meta name="profileorguniten" content="" />
<meta name="profileorgunitid" content="" />
<meta name="profiledepartment" content="" />
<meta name="profiledepartmenten" content="" />
<meta name="profilephone" content="" />
<meta name="profileemail" content="" />
<meta name="personimageurl" content="" />
<meta name="personimagealt" content="" />
<meta name="profileprofiletext" content="" />
<meta name="robots" content="index, follow" />
<link rel="canonical" href="https://studieinformation.dtu.dk/service/noegletalekstern" />
<!-- Server: WN1MDWK000012 -->

	<!-- START: LEGACY HEAD -->

		<link rel="stylesheet" type="text/css" href="//www.dtu.dk/css/common/init_alldevices.min.css?ver=0.0.0+00000.SHA.VERSION-NOT-SPECIFIED" media="all" />
		<link rel="stylesheet" type="text/css" href="//www.dtu.dk/css/www/base_mobile.min.css?ver=0.0.0+00000.SHA.VERSION-NOT-SPECIFIED" media="screen and (max-width: 760px)" />
		<link rel="stylesheet" type="text/css" href="//www.dtu.dk/css/www/base_desktop.min.css?ver=0.0.0+00000.SHA.VERSION-NOT-SPECIFIED" media="print, screen and (min-width: 761px)" />


		<script src="//www.dtu.dk/js/jQuery/1.8.2/jquery.min.js" type="text/javascript"></script>
		<script src="//www.dtu.dk/js/jQuery/ui/jquery-ui-1.9.0.min.js" type="text/javascript"></script>

		<!-- AJAX BUNDLE (\js\ajax\ajax.js.bundle) -->
		<script src="//www.dtu.dk/js/libs/ajax/ajax.min.js" type="text/javascript"></script>

		<script type="text/javascript">jqNetmester = jQuery.noConflict();</script>


			<!-- DESKTOP OR MOBILE BUNDLE (\js\desktop.js.bundle) -->
			<script type="text/javascript">
				if (document.documentElement.clientWidth < 761) {
					jqNetmester('html').addClass("range_0");
				}

				if (jqNetmester('html').hasClass("range_0")) {
					src='//www.dtu.dk/js/mobile.min.js?ver=0.0.0+00000.SHA.VERSION-NOT-SPECIFIED';
					} else {
						src='//www.dtu.dk/js/desktop.min.js?ver=0.0.0+00000.SHA.VERSION-NOT-SPECIFIED';
					}
					document.write('<' + 'script src="' + src + '"' + ' type="text/javascript"><' + '/script>');
			</script>


		<script src="//www.dtu.dk/js/libs/jquery.datepicker-da.js" type="text/javascript"></script>




		<!--[if IE 7]><link rel="stylesheet" type="text/css" href="//www.dtu.dk/css/common/ie7.min.css"><![endif]-->

		<META NAME="ROBOTS" CONTENT="NOINDEX, NOFOLLOW"><!-- AKM-WEB-23: tag manager container head /23/04/2020 -->
<!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-W25B4BH');</script>
<!-- End Google Tag Manager -->

<style>
 .subservicemenu a[title="DTU Systembiologi"] {
        display: none !important;
 }
 .subservicemenu a[title="DTU Systems Biology"] {
        display: none !important;
 }
.subservicemenu a[title="Adgangskursus"] {
        display: none !important;
 }
.subservicemenu a[title="DTU Admission Course"] {
        display: none !important;
 }



 .subservicemenu a[title="DTU Bibliotek"] {
        display: none !important;
 }

 .subservicemenu a[title="DTU Library"] {
        display: none !important;
 }

.subservicemenu a[title="DTU Business"] {
        display: none !important;
 }
 .subservicemenu a[title="DTU Cen"] {
        display: none !important;
 }
 .subservicemenu a[title="DTU Cen "] {
        display: none !important;
 }
.subservicemenu a[title="Forskning i Bæredygtig Energi"] {
        display: none !important;
 }
 .subservicemenu a[title="DTU National Laboratory for Sustainable Energy"] {
        display: none !important;
 }
</style>


		<link rel="stylesheet" type="text/css" href="//www.dtu.dk/css/common/print.min.css?ver=1400" media="print" />
		<link rel="shortcut icon" href="//www.dtu.dk/favicon.ico" />
		<link href="//www.dtu.dk/dist/css/style-legacy-7d8b03c15a.css" sri="sha256-AOCUlCX2ALK+J1k5AjCXFBbnSlHJ08EuIJa5fAPWg7I= sha384-APmedoOzZ+T09VphK9lRCG9FbhwopAwvphYZ9eT4s9ToXFid7Yhj8sKKRYS968HM sha512-mmA0BFMG19roZNYKxYVcJDXCdoaFFAjzpKlDdRfT7GrEkqrJBQwmFbqy85ZvlgV6j4pIWUqQA+g3pJkDhYlUwA==" rel="stylesheet" />
<!--
<PageMap>
	<DataObject type="document">

				<Attribute name="paths">_subsites</Attribute>
				<Attribute name="paths">_subsites_studieordninger</Attribute>
				<Attribute name="paths">_subsites_studieordninger_studieordninger</Attribute>
				<Attribute name="paths">_subsites_studieordninger_studieordninger_forside</Attribute>
				<Attribute name="paths">_subsites_studieordninger_studieordninger_forside_service</Attribute>
				<Attribute name="paths">_subsites_studieordninger_studieordninger_forside_service_noegletalekstern</Attribute>
		<Attribute name="language">da</Attribute>
		<Attribute name="type">articlehtml</Attribute>
		<Attribute name="date">20220208</Attribute>
	</DataObject>
</PageMap>
-->

	<!-- END: LEGACY HEAD -->

	<!-- START: HEAD -->

	<!-- END: HEAD -->

	<!--googleon: index-->




    <link href="https://fast.fonts.com/t/1.css?apiType=css&projectid=5cebbbb5-be88-4802-9d8e-4388b2411419" rel="stylesheet" />

    <script type="text/javascript">
        function setCookie(c_name, value, exdays) {
            var exdate = new Date();
            exdate.setDate(exdate.getDate() + exdays);
            var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
            document.cookie = c_name + "=" + c_value+";path=/;";
        }

        function setLanguage(language) {
            console.log("language: " + language);
            setCookie('{DTUevalPublicLanguage}', language, 3650);
            //location.href = updateQueryStringParameter(location.href, "language", language); //This line is working - but we need an English master for ViewBag.ScrapingUrl
            location.reload();
            //if (language == "da-DK") {
            //    location.href = "http://dtu.dk/dansk";
            //} else {
            //    location.href = "http://dtu.dk/english";
            //}
        }
        //http://stackoverflow.com/questions/5999118/add-or-update-query-string-parameter
        function updateQueryStringParameter(uri, key, value) {
            var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
            var separator = uri.indexOf('?') !== -1 ? "&" : "?";
            if (uri.match(re)) {
                return uri.replace(re, '$1' + key + "=" + value + '$2');
            }
            else {
                return uri + separator + key + "=" + value;
            }
        }
    </script>




</head>

<body id="body" class="articlehtml">
    <div style="position:relative;z-index:-1;width:0;height:0;"><!-- SVG SPRITE --><svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><symbol viewBox="0 0 341.751 341.751" id="close-icon"><path d="M-.007 311.525L311.535.072 341.7 30.246 30.16 341.699z"/><path d="M.047 30.226L30.212.052l311.542 311.454-30.166 30.174z"/></symbol><symbol viewBox="0 0 17 17" id="cross-icon" xmlns="http://www.w3.org/2000/svg"><path d="M16 7.5H9.5V1a1 1 0 10-2 0v6.5H1a1 1 0 000 2h6.5V16a1 1 0 102 0V9.5H16a1 1 0 000-2z"/></symbol><symbol viewBox="0 0 48.555 70.832" id="dtu-logo" xmlns="http://www.w3.org/2000/svg"><path d="M3 0v.031h-.094l-.03.031h-.032l-.032.032h-.03v.03L2.75.126l-.03.03c-.088.088-.125.211-.125.406v24.625c0 .192.037.323.125.407.083.082.216.125.406.125h6.438c2.504 0 4.046-.55 4.968-1.75 1.368-1.637 1.407-4.297 1.407-8.344v-5.531c0-4.053-.04-6.678-1.407-8.313C13.61.58 12.067 0 9.563 0H3.03zm3.688 3h2.25c1.005 0 1.598.163 2.062.719.718.86.781 2.599.781 6.094v6.093c0 3.492-.063 5.234-.781 6.094-.464.556-1.057.719-2.063.719h-2.25zM45.82.55V.515l-.001-.018-.002-.032-.002-.016-.001-.017-.002-.015-.002-.013-.004-.015-.002-.014L45.8.36l-.004-.014-.005-.012-.004-.013-.01-.025-.01-.022-.006-.012-.006-.01-.006-.01-.018-.03-.007-.01-.03-.036-.016-.017c-.083-.083-.2-.142-.395-.142h-3.009c-.195 0-.312.06-.395.142-.087.087-.146.205-.146.4v18.189c0 1.9-.143 3.027-.758 3.706-.42.459-1.015.684-1.845.684-.747 0-1.318-.21-1.753-.69-.585-.643-.767-1.733-.767-3.7V.549c0-.194-.053-.312-.14-.4-.085-.082-.2-.14-.397-.14H33.06a.528.528 0 00-.395.14c-.087.088-.14.206-.14.4v18.195c0 2.65.355 4.31 1.41 5.468 1.093 1.202 2.744 1.842 5.25 1.842 2.538 0 4.164-.68 5.17-1.847 1.177-1.367 1.47-3.002 1.47-5.463zM26.37 25.18l-.001.019v.016l-.001.018-.002.032-.001.015-.002.016-.002.015-.002.014-.002.015-.004.014-.004.014-.004.014-.004.012-.01.025-.005.011-.005.013-.005.011-.006.011-.005.01-.006.012-.006.01-.007.01-.006.009-.008.01-.006.009-.007.009-.016.017-.017.016c-.082.083-.2.142-.395.142h-3.296a.519.519 0 01-.39-.142c-.089-.084-.146-.205-.146-.396V3.252h-3.868c-.195 0-.312-.057-.4-.146-.088-.083-.142-.2-.142-.395V.542c0-.195.054-.312.142-.4a.544.544 0 01.4-.141h12.114a.54.54 0 01.397.141c.082.088.14.205.14.4v2.169c0 .195-.058.312-.14.395-.09.089-.205.146-.397.146h-3.87zm22.18 13.41l-10.332 5.425c-13.384-5.205-14.511-5.205-27.89 0L-.004 38.59l10.332-5.425c13.379 5.205 14.507 5.205 27.89 0zm0 13.41l-10.332 5.425c-13.384-5.205-14.511-5.205-27.89 0L-.004 52l10.332-5.424c13.379 5.205 14.507 5.205 27.89 0zm0 13.4l-10.332 5.425c-13.384-5.205-14.511-5.205-27.89 0L-.004 65.4l10.332-5.42c13.379 5.205 14.507 5.205 27.89 0z"/></symbol><symbol viewBox="0 0 49 11" fill-rule="evenodd" clip-rule="evenodd" stroke-linejoin="round" stroke-miterlimit="2" id="dtu-logo-bit" xmlns="http://www.w3.org/2000/svg"><path d="M48.554 5.425L38.222 10.85c-13.384-5.205-14.511-5.205-27.89 0L0 5.425 10.332 0c13.379 5.205 14.507 5.205 27.89 0l10.332 5.425z" fill-rule="nonzero"/></symbol><symbol viewBox="0 0 24 24" id="facebook" xmlns="http://www.w3.org/2000/svg"><path d="M15.997 3.985h2.191V.169C17.81.117 16.51 0 14.996 0c-3.159 0-5.323 1.987-5.323 5.639V9H6.187v4.266h3.486V24h4.274V13.267h3.345l.531-4.266h-3.877V6.062c.001-1.233.333-2.077 2.051-2.077z"/></symbol><symbol clip-rule="evenodd" fill-rule="evenodd" stroke-linejoin="round" stroke-miterlimit="2" viewBox="0 0 15.74 11.031" id="icon-arrow-left"><path d="M5.516 11.031l.848-.849-4.067-4.067H15.74v-1.2H2.297L6.364.848 5.516 0 0 5.515z" fill-rule="nonzero"/></symbol><symbol viewBox="0 0 15.74 11.031" id="icon-arrow-right" xmlns="http://www.w3.org/2000/svg"><path d="M10.224 0l-.848.849 4.067 4.067H0v1.2h13.443l-4.067 4.067.848.848 5.516-5.515L10.224 0z"/></symbol><symbol viewBox="0 0 6.64 11.57" id="icon-chevron-left" xmlns="http://www.w3.org/2000/svg"><path d="M5.79 11.57l.85-.85L1.7 5.79 6.64.85 5.79 0 0 5.79l5.79 5.78z"/></symbol><symbol viewBox="0 0 6.64 11.57" id="icon-chevron-right" xmlns="http://www.w3.org/2000/svg"><path d="M.85 0L0 .85l4.94 4.93L0 10.72l.85.85 5.79-5.79L.85 0z"/></symbol><symbol viewBox="0 0 512 512" id="icon-email" xmlns="http://www.w3.org/2000/svg"><path d="M467 61H45C20.218 61 0 81.196 0 106v300c0 24.72 20.128 45 45 45h422c24.72 0 45-20.128 45-45V106c0-24.72-20.128-45-45-45zm-6.214 30L256.954 294.833 51.359 91h409.427zM30 399.788V112.069l144.479 143.24L30 399.788zM51.213 421l144.57-144.57 50.657 50.222c5.864 5.814 15.327 5.795 21.167-.046L317 277.213 460.787 421H51.213zM482 399.787L338.213 256 482 112.212v287.575z"/></symbol><symbol viewBox="0 0 24 24" id="linkedin" xmlns="http://www.w3.org/2000/svg"><path d="M23.994 24v-.001H24v-8.802c0-4.306-.927-7.623-5.961-7.623-2.42 0-4.044 1.328-4.707 2.587h-.07V7.976H8.489v16.023h4.97v-7.934c0-2.089.396-4.109 2.983-4.109 2.549 0 2.587 2.384 2.587 4.243V24zM.396 7.977h4.976V24H.396zM2.882 0C1.291 0 0 1.291 0 2.882s1.291 2.909 2.882 2.909 2.882-1.318 2.882-2.909A2.884 2.884 0 002.882 0z"/></symbol><symbol viewBox="0 0 17 17" id="minus-icon" xmlns="http://www.w3.org/2000/svg"><path d="M16 7.5H1a1 1 0 000 2h15a1 1 0 000-2z"/></symbol><symbol viewBox="0 0 512 512" id="plus-icon" xmlns="http://www.w3.org/2000/svg"><path d="M289.391 222.609V0h-66.782v222.609H0v66.782h222.609V512h66.782V289.391H512v-66.782z"/></symbol><symbol viewBox="0 0 512 512" id="search-icon"><path d="M225.474 0C101.151 0 0 101.151 0 225.474c0 124.33 101.151 225.474 225.474 225.474 124.33 0 225.474-101.144 225.474-225.474C450.948 101.151 349.804 0 225.474 0zm0 409.323c-101.373 0-183.848-82.475-183.848-183.848S124.101 41.626 225.474 41.626s183.848 82.475 183.848 183.848-82.475 183.849-183.848 183.849z"/><path d="M505.902 476.472L386.574 357.144c-8.131-8.131-21.299-8.131-29.43 0-8.131 8.124-8.131 21.306 0 29.43l119.328 119.328A20.74 20.74 0 00491.187 512a20.754 20.754 0 0014.715-6.098c8.131-8.124 8.131-21.306 0-29.43z"/></symbol><symbol viewBox="0 0 512 512" id="twitter" xmlns="http://www.w3.org/2000/svg"><path d="M512 97.248c-19.04 8.352-39.328 13.888-60.48 16.576 21.76-12.992 38.368-33.408 46.176-58.016-20.288 12.096-42.688 20.64-66.56 25.408C411.872 60.704 384.416 48 354.464 48c-58.112 0-104.896 47.168-104.896 104.992 0 8.32.704 16.32 2.432 23.936-87.264-4.256-164.48-46.08-216.352-109.792-9.056 15.712-14.368 33.696-14.368 53.056 0 36.352 18.72 68.576 46.624 87.232-16.864-.32-33.408-5.216-47.424-12.928v1.152c0 51.008 36.384 93.376 84.096 103.136-8.544 2.336-17.856 3.456-27.52 3.456-6.72 0-13.504-.384-19.872-1.792 13.6 41.568 52.192 72.128 98.08 73.12-35.712 27.936-81.056 44.768-130.144 44.768-8.608 0-16.864-.384-25.12-1.44C46.496 446.88 101.6 464 161.024 464c193.152 0 298.752-160 298.752-298.688 0-4.64-.16-9.12-.384-13.568 20.832-14.784 38.336-33.248 52.608-54.496z"/></symbol></svg></div>
	<form method="post" action="//www.dtu.dk/service/NoegletalEkstern?hidecontent=true" id="mainform">
<div class="aspNetHidden">
<input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="ylpBTULzjUbjcEAuLuMltmCbFvMy0GImgKoizFUugSwfTrR8+mkLSAfqnVZC8JnDk027nf5rBHaItpKInvrZnGz+oljczVNkGGko20U2lowy9d86Y+G10TVRkTZYVlF6NBrUDfV6jscUQBRYMSykiKW2Ke3DGTdWZbWDdBctRO458n8J+hZ1C5y5znQvNDBAqYVQHfp5M2Ei0UItgvJimjWw5+7g5mGymjBk6gJIf3nA+qMJjbGeLOi4aNyMj5aC8b7sV44Ug/4DTBRGEPGNFwmFUMJgoPRJqnKM6dfhj/ZUKow0z5Bm+0QEF3EeJyHt7XdeWc3jZkPxhT7wgJD6A3bAU1ltmQ4Le5aX+zcE8HfidkHLNnaTa+VgfvnDlo4BDEeRm7yKH468+e2R8o9IFTo2oEI3ZZ7j1hbvLIwVEzyoRhOmZgynCkC3l3PGy2jEt5MyoPsSC8i9xQr2Ulx5XEHlnxKnVw9YcePLn0l4cI4UdVvOQqtjkV9uo5/K+h7MwiTyXHoI01FEXivnNcg8Ww/zl2ZOr0pjdZ158Ub2HMES6++eBckmEuYFWuZB3ELy09jLTrrlhGWk1FMfEzxr+9zmc3LeHckbWxaHn+Cj1WuVY7Hu" />
</div>

<div class="aspNetHidden">

	<input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="8800DAED" />
</div>
		<div class="globalcontainer">
			<!--googleoff: index-->



<header>

<div >
    <div class="subservicemenuHeader subservicemenu"></div>
    <div class="servicemenu" >
        <div class="container_12">
           <div class="grid_3 minHeight">

                <a id="ctl10_ServiceMenuHeader_ServiceMenuLogo" href="https://www.dtu.dk">
                    <span class="servicemenu__link-text">DTU.dk</span>
                </a>

</div>



            <div class="grid_6 minHeight">
                <nav>

                            <div id="ctl10_ServiceMenuHeader_ServiceMenuItems_ServiceMenuItem_0" class="item itemmenu Header quickdropinstitute" onclick="ToogleServicemenu(this, &#39;Header&#39;, &#39;Headerc216ff31-cc0b-433d-aa6a-543d609b8aaf&#39;)">
	Institutter &amp; Centre<div class="servicemenuitems">
		<div class="container_12">
			<div>
				<img title="Luk" class="close" onclick="HideServicemenu(this, &#39;Header&#39;)" src="//www.dtu.dk/images/buttons/close1.png" alt="Luk" /><!-- Image Url: /images/buttons/close1.png -->
			</div><div class="clear"></div><div class="grid_9 col3 divider">
				<h2>Institutter og centre</h2><ul><li><a href="https://www.aqua.dtu.dk/" title="DTU Aqua" target="_blank">DTU Aqua</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/bioengineering/bioengineering_old/forside" title="DTU Bioengineering" target="_blank">DTU Bioengineering</a></li><li><a href="https://www.biosustain.dtu.dk/danish/" title="DTU Biosustain" target="_blank">DTU Biosustain</a></li><li><a href="https://www.byg.dtu.dk/" title="DTU Byg" target="_blank">DTU Byg</a></li><li><a href="https://www.compute.dtu.dk/" title="DTU Compute" target="_blank">DTU Compute</a></li><li><a href="https://www.elektro.dtu.dk/" title="DTU Elektro" target="_blank">DTU Elektro</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/energikonvertering/dtu_energikonvertering_old/forside" title="DTU Energi" target="_blank">DTU Energi</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/engineering_technology/engineering_technology_old/forside" title="DTU Engineering Technology " target="_blank">DTU Engineering Technology </a></li></ul><ul><li><a href="https://www.entrepreneurship.dtu.dk/danish/" title="DTU Entrepreneurship" target="_blank">DTU Entrepreneurship</a></li><li><a href="https://www.fotonik.dtu.dk/" title="DTU Electro" target="_blank">DTU Electro</a></li><li><a href="https://www.fysik.dtu.dk/" title="DTU Fysik" target="_blank">DTU Fysik</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/foedevareinstituttet/dtu_foedevareinstituttet_old/forside" title="DTU Fødevareinstituttet" target="_blank">DTU Fødevareinstituttet</a></li><li><a href="https://www.kemi.dtu.dk/" title="DTU Kemi" target="_blank">DTU Kemi</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/kemiteknik/dtu_kemiteknik_old/forside" title="DTU Kemiteknik" target="_blank">DTU Kemiteknik</a></li><li><a href="https://learnforlife.dtu.dk/" title="DTU  Learn for Life" target="_blank">DTU  Learn for Life</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/management_engineering/dtu_management_engineering_old/forside" title="DTU Management " target="_blank">DTU Management </a></li></ul><ul><li><a href="https://www.mek.dtu.dk/" title="DTU Mekanik" target="_blank">DTU Mekanik</a></li><li><a href="https://www.env.dtu.dk/" title="DTU Miljø" target="_blank">DTU Miljø</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/andre_universitetsenheder/nanolab/dtu_nanolab-old/forside" title="DTU Nanolab" target="_blank">DTU Nanolab</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/andre_universitetsenheder/skylab/skylab_english-old/forside" title="DTU Skylab" target="_blank">DTU Skylab</a></li><li><a href="https://www.space.dtu.dk/" title="DTU Space" target="_blank">DTU Space</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/sundhedsteknologi/dtu_sundhedsteknologi_old/forside" title="DTU Sundhedsteknologi" target="_blank">DTU Sundhedsteknologi</a></li><li><a href="https://windenergy.dtu.dk/" title="DTU Vindenergi" target="_blank">DTU Vindenergi</a></li></ul>
			</div><div class="grid_3">
				<h2>Forskningsgrupper</h2><ul><li><a title="Forskningsgrupper" href="https://www.dtu.dk/forskning/find-forskning/institutter-og-centre#Forskningsgrupper">Forskningsgrupper</a></li></ul>
			</div>
		</div>
	</div>
</div>
                        <div class="item separator"><img src="//www.dtu.dk/images/modules/servicemenu/menu_divider.png" alt="" /></div>
                            <div id="ctl10_ServiceMenuHeader_ServiceMenuItems_ServiceMenuItem_1" class="item itemmenu Header quickdropshortcuts" onclick="ToogleServicemenu(this, &#39;Header&#39;, &#39;Header34b4b505-a037-4fb1-a0e5-90b912879a07&#39;)">
	Genveje<div class="servicemenuitems">
		<div class="container_12">
			<div>
				<img title="Luk" class="close" onclick="HideServicemenu(this, &#39;Header&#39;)" src="//www.dtu.dk/images/buttons/close1.png" alt="Luk" /><!-- Image Url: /images/buttons/close1.png -->
			</div><div class="clear"></div><div class="grid_3 divider">
				<h2 class="minHeight">Genveje</h2><ul>
    <li><a href="https://www.dtu.dk/soeg?area=samesite&amp;entity=persons">Telefonbog</a></li>
    <li><a href="https://www.dtu.dk/om-dtu/kontakt-og-besoeg/find-vej">Find vej/kort</a></li>
    <li><a href="https://www.dtu.dk/nyheder/presseservice">Presseservice</a></li>
    <li><a href="https://www.dtu.dk/om-dtu/kontakt-og-besoeg/for-leverandoerer">For leverand&oslash;rer (CVR og EAN)</a></li>
</ul>
			</div><div class="grid_3 divider">
				<h2 class="minHeight"></h2><ul>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://kurser.dtu.dk/" target="_blank">Kursusbasen</a> </li>
    <li><a href="https://studieinformation.dtu.dk/">Studieinformation for studerende</a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.inside.dtu.dk" target="_blank">DTU Inside (login)</a> </li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.adgangskursus.dtu.dk/" target="_blank">DTU Adgangskursus</a></li>
</ul>
			</div><div class="grid_3">
				<h2 class="minHeight"></h2><ul>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.dtu.dk/om-dtu/job-og-karriere" target="_blank">Job og Karriere </a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.alumni.dtu.dk/" target="_blank">DTU Alumni</a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.polyteknisk.dk/" target="_blank">Webshop</a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.bibliotek.dtu.dk/" target="_blank">DTU Bibliotek</a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://orbit.dtu.dk/" target="_blank">DTU Orbit (Forskningsdatabase)</a></li>
</ul>
			</div>
		</div>
	</div>
</div>
                        <div class="item separator"><img src="//www.dtu.dk/images/modules/servicemenu/menu_divider.png" alt="" /></div>
                            <div id="ctl10_ServiceMenuHeader_ServiceMenuItems_ServiceMenuItem_2" class="item">
	<a title="Kontakt" href="https://studieinformation.dtu.dk/service/kontakt">Kontakt</a>
</div>
                        <div class="item separator"><img src="//www.dtu.dk/images/modules/servicemenu/menu_divider.png" alt="" /></div>
                            <div id="ctl10_ServiceMenuHeader_ServiceMenuItems_ServiceMenuItem_3" class="item">



        <a href="javascript:setLanguage('en-GB')">English</a>




</div>

                </nav>
            </div>
            <div class="grid_3 subsitesearch">



<div id="top-search-wrapper" class="top-search-wrapper mobile-menu-dropdown">
    <div id="ctl10_ServiceMenuHeader_SearchBox_SearchboxPanel" class="search">

        <input name="ctl10$ServiceMenuHeader$SearchBox$searchword" type="text" id="ctl10_ServiceMenuHeader_SearchBox_searchword" class="inputtext" />
        <span class="inside-search-btn">
            <input type="submit" name="ctl10$ServiceMenuHeader$SearchBox$searchbutton" value="" onclick="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl10$ServiceMenuHeader$SearchBox$searchbutton&quot;, &quot;&quot;, true, &quot;&quot;, &quot;&quot;, false, false))" id="ctl10_ServiceMenuHeader_SearchBox_searchbutton" title="Søg" class="inputsubmit" />
        </span>

	</div>

    <div id="ctl10_ServiceMenuHeader_SearchBox_SearchButtons" class="hide-desktop search-choice">

        <ul>
            <li data-tabsearch="1">
                <label for="collection1">Studieinformation</label><input value="freeText" name="ctl10$ServiceMenuHeader$SearchBox$" type="radio" id="collection1" /></li>
            <li data-tabsearch="2">
                <label for="collection2">Personer</label><input value="person" name="ctl10$ServiceMenuHeader$SearchBox$" type="radio" id="collection2" /></li>
            <li data-tabsearch="3">
                <label for="collection3">Publikationer</label><input value="publication" name="ctl10$ServiceMenuHeader$SearchBox$" type="radio" id="collection3" /></li>
            <li data-tabsearch="4">
                <label for="collection4">Projekter</label><input value="project" name="ctl10$ServiceMenuHeader$SearchBox$" type="radio" id="collection4" /></li>
        </ul>

	</div>

</div>



</div>
        </div>
    </div>

</div>



    <div class="pageheader">

        <div id="ctl10_PageHeaderOverlay" class="pageheaderoverlay">


            <div class="container_12">

                <div class="grid_6 pageheadertop sitelogo linkset4">
                    <a title="Forside" class="websiteLogoLink logo-missing mobilelogo-missing mobilelogosmall-missing" href="https://studieinformation.dtu.dk/">

    <span class="sitetextlogo">Studieinformation</span>


</a>


                    <div class="mobilemenuNavigation">
                        <div>

                            <div class="mobileTopMenuButton" id="topMenuButton" data-menu-id="mobile-menu" data-button="/images/modules/mobile/menu.png" data-button-toggle="/images/modules/mobile/menuSelected.png">
                                <img src="//www.dtu.dk/images/modules/mobile/menu.png" alt="" />
                            </div>

	</div>

                        <div>

                            <div class="mobileTopMenuButton" id="searchButton" data-menu-id="top-search-wrapper" data-button="/images/modules/mobile/search.png" data-button-toggle="/images/modules/mobile/searchSelected.png">
                                <img src="//www.dtu.dk/images/modules/mobile/search.png" alt="" />
                            </div>

	</div>
                        <div class="mobileTopMenuButton" id="shortcutsButton" data-menu-id="mobile-shortcuts-menu" data-button="/images/modules/mobile/shortcuts.png" data-button-toggle="/images/modules/mobile/shortcutsSelected.png">
                            <img src="//www.dtu.dk/images/modules/mobile/shortcuts.png" alt="" />
                        </div>
                    </div>
                </div>
                <div class="grid_6 pageheadertop">


	                <a title="Danmarks Tekniske Universitet" class="websitelogoright__link" href="https://www.dtu.dk"><img id="ctl10_ctl08_Img1" alt="DTU" class="websitelogoright__link-image" src="//www.dtu.dk/images/grid/dtulogo2_colour.png" alt="" /><!-- Image Url: /images/grid/dtulogo2_colour.png --></a>

                </div>
                <div class="clear hideInPrint"></div>



        <nav>
            <ul id="mainmenu" class="mainmenu mainmenusimple">


        <li class="mainmenuitem item0">

            <div class="mainmenubutton first linkset4">
                <div class="mainmenulink mainmenulink--hover">
                    <a title="Diplomingeniør" class="mainButton" href="https://studieinformation.dtu.dk/diplomingenioer">Diplomingeni&#248;r</a>



                </div>
            </div>

        </li>



        <li class="mainmenuitem item1">

            <div class="mainmenubutton linkset4">
                <div class="mainmenulink mainmenulink--hover">
                    <a title="Bachelor" class="mainButton" href="https://studieinformation.dtu.dk/bachelor">Bachelor</a>



                </div>
            </div>

        </li>



        <li class="mainmenuitem item2">

            <div class="mainmenubutton linkset4">
                <div class="mainmenulink mainmenulink--hover">
                    <a title="Kandidat" class="mainButton" href="https://studieinformation.dtu.dk/kandidat">Kandidat</a>



                </div>
            </div>

        </li>



        <li class="mainmenuitem last item3">

            <div class="mainmenubutton linkset4">
                <div class="mainmenulink mainmenulink--hover">
                    <a title="DTU&#39;s regler" class="mainButton" href="https://studieinformation.dtu.dk/regler">DTU&#39;s regler</a>



                </div>
            </div>

        </li>



            </ul>
            <div class="mainmenu mainmenuBackground"><div class="mainmenusubhoverBackground">
            <img src="//www.dtu.dk/images/modules/megamenu/megamenu_bg.png" />
            </div></div>
        </nav>



                <div class="breadcrumb-print">

                    <div id="ctl10_ctl11_Breadcrumb">

    <div class="breadcrumb linkset6 grid_10">


                <a href="https://studieinformation.dtu.dk/" title="Forside">
                    Forside
                </a>

                <img src="//www.dtu.dk/images/modules/breadcrumb/separator.jpg" alt="" class="screenSeparator" /><img src="//www.dtu.dk/images/modules/breadcrumb/printSeparator.png" alt="" class="printSeparator" />

                <a class="underline" href="#" title="


    Kursusevalueringer


">



    Kursusevalueringer



                </a>

    </div>


		</div>

	</div>

            </div>


</div>

    </div>





</header></form>



<script id="mobile-menu-template" type="text/x-jquery-tmpl">

    <div class="menu-item ${CssClass}">
        <a href="${Url}" title="${Title}">${MenuTitle}</a>

        {{if HasChildren}}
            <div class="open-submenu" onclick="renderMenu('${Id}', 'next', 'Da', 'hidecontent=true')"> </div>
        {{/if}}
    </div>

</script>

<div id="mobile-menu" class="mobile-menu mobile-menu-dropdown">
    <div class="back-menu-item"></div>
    <div class="prev menu-wrapper"></div>
    <div class="current menu-wrapper"></div>
    <div class="next menu-wrapper"></div>
    <div class="clear spinner"></div>
</div>

<script type="text/javascript">
    renderMenu('df2e7462-00cb-403a-aa3e-a7072356f3e1', 'current', 'Da', 'hidecontent=true');
</script>
<div id="mobile-shortcuts-menu" class="mobile-shortcuts-menu mobile-menu-dropdown"></div>
<div class="menu-overlay"></div>

<div id="ctl10_ctl03_topmenu" class="topmenu empty">
    <nav>
        <ul class="container_12 topmenuitems linkset1">



        </ul>
    </nav>
    <div class="clear"></div>
</div>




						<div id="outercontent" class="page-articlehtml">


<div class="container_12">


    <div id="outercontent_0_contentheader_0_Breadcrumb">

    <div class="breadcrumb linkset6 grid_10">


                <a href="https://studieinformation.dtu.dk/" title="Forside">
                    Forside
                </a>

                <img src="//www.dtu.dk/images/modules/breadcrumb/separator.jpg" alt="" class="screenSeparator" /><img src="//www.dtu.dk/images/modules/breadcrumb/printSeparator.png" alt="" class="printSeparator" />

                <a class="underline" href="#" title="


    Kursusevalueringer


">



    Kursusevalueringer



                </a>

    </div>


</div>
    <div class="clear hideInPrint"></div>


    <div class="clear hideInPrint"></div>

    <div id="outercontent_0_LeftColumn" class="grid_3 leftcolumn minHeight">







</div>


    <div id="outercontent_0_ContentColumn" class="content grid_6 container_6">


        <div class="contentModulesContainer">

            <div class="clear hideInPrint"></div>
        </div>

        <div class="clear hideInPrint"></div>

        <h1 id="outercontent_0_content_0_ContentHeading" class="invisible">


    Kursusevalueringer


</h1>

<div class="content linkset8 lineheight13_18 margintop3">

</div>







<div id="content">


<link rel="stylesheet" type="text/css" href="/Areas/Results/Content/ResultPublicForCourseCatalogBasics.css" />
<link rel="stylesheet" type="text/css" href="/Areas/Results/Content/ResultPublicForCourseCatalog.css"/>
<link rel="stylesheet" type="text/css" href="/Areas/Results/Content/ResultPublicForCourseSchemas.css" />
<link rel="stylesheet" type="text/css" media="print" href="/Areas/Results/Content/ResultPublicForCoursePrint.css" />


<div id="TitleBlock" class="grid_6 clearleft">

    <h1>Kursusevalueringer</h1>
    <p>
        Efter hver undervisningsperiode evaluerer de studerende de kurser, som de har deltaget i. Kursusevalueringerne er blot ét blandt flere elementer i vurderingen af undervisningen. Uddannelsernes og undervisningens kvalitet kommer også til udtryk gennem studiestartsevalueringerne, uddannelsesevalueringerne, akkrediteringsarbejdet og det løbende arbejde med at udvikle og forbedre uddannelsernes og undervisningens kvalitet.<br /><br />

 Resultaterne af denne evaluering er offentlig tilgængelig.<br /><br />

 Der er 6 undervisningsperioder:<br />
 Et efterårssemester og et forårssemester på hver 13 uger.<br />
 Heldagsperioder i januar, juni, juli og august på hver 3 uger.
    </p>

</div>

<div class="grid_6 clearright">


<div id="CourseResultsPublicContainer" class="grid_6 clearleft">
    <h2>Resultater : 01005 Matematik 1 E22</h2>
    <div class="pad">
        <h5>Statistik</h5>
        <table>
            <tr>
                <td>1014</td>
                <td>kunne besvare dette evalueringsskema</td>
            </tr>
            <tr>
                <td>345</td>
                <td>har besvaret dette evalueringsskema</td>
            </tr>
            <tr>
                <td>3</td>
                <td>har tilkendegivet ikke at have fulgt kurset</td>
            </tr>

        </table>

            <div class="noprint">svarrate</div>
            <div id="ResultsMeasurableBarContainer">
                <div class="ResultsMeasurableBarRed" style="width: 34.12%"></div>
            </div>
            <div id="PercentageResult"><span>34,12%</span></div>
            <div><span>svarprocent 345 / (1014 - 3)</span></div>

    </div>
</div>





</div>
<div id="SearchFormularPanel" class="grid_12 clearleft clearright">
<form action="/CourseSearch" method="post">

<div id="CourseSelectorContainer">

    <!-- select a course -->
    <div class="clearleft clearright">
        <span>V&#230;lg kursus</span>
        <input name="courseNumber" type="text" value="01005" maxlength="5" id="CourseCodeTextbox" />
    </div>
    <!-- select a period for the course -->
    <div class="clearleft clearright">
        <span>V&#230;lg periode</span>
        <select name="termUid" id="PeriodDropDownList">
            <option value="">Alle</option>
                <option value="F-24-13" >F24-13</option>
                <option value="E-23-03" >E23-03</option>
                <option value="E-23-13" >E23-13</option>
                <option value="F-23-03AUG" >F23-03 august</option>
                <option value="F-23-03JUL" >F23-03 juli</option>
                <option value="F-23-03JUN" >F23-03 juni</option>
                <option value="F-23-13" selected>F23-13</option>
                <option value="E-22-03" >E22-03</option>
                <option value="E-22-13" >E22-13</option>
                <option value="F-22-03AUG" >F22-03 august</option>
                <option value="F-22-03JUL" >F22-03 juli</option>
                <option value="F-22-03JUN" >F22-03 juni</option>
                <option value="F-22-13" >F22-13</option>
                <option value="E-21-03" >E21-03</option>
                <option value="E-21-13" >E21-13</option>
                <option value="F-21-03AUG" >F21-03 august</option>
                <option value="F-21-03JUL" >F21-03 juli</option>
                <option value="F-21-03JUN" >F21-03 juni</option>
                <option value="F-21-13" >F21-13</option>
                <option value="E-20-03" >E20-03</option>
                <option value="E-20-13" >E20-13</option>
                <option value="F-20-03AUG" >F20-03 august</option>
                <option value="F-20-03JUL" >F20-03 juli</option>
                <option value="F-20-03JUN" >F20-03 juni</option>
                <option value="F-20-13" >F20-13</option>
                <option value="E-19-03" >E19-03</option>
                <option value="E-19-13" >E19-13</option>
                <option value="F-19-03AUG" >F19-03 august</option>
                <option value="F-19-03JUL" >F19-03 juli</option>
                <option value="F-19-03JUN" >F19-03 juni</option>
                <option value="F-19-13" >F19-13</option>
                <option value="E-18-03" >E18-03</option>
                <option value="E-18-13" >E18-13</option>
                <option value="F-18-03AUG" >F18-03 august</option>
                <option value="F-18-03JUL" >F18-03 juli</option>
                <option value="F-18-03JUN" >F18-03 juni</option>
                <option value="F-18-13" >F18-13</option>
        </select>
        <input type="submit" name="SearchButton" value="S&#248;g" id="SearchButton"/>
    </div>
</div>

</form></div>

<div class="grid_12 clearright clearmarg" id="Results">


<h2 style="page-break-after:always">Resultater : 01005 Matematik 1 E22</h2>



<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint">Jeg synes, at…</h5>

    <!-- Tabellerne renderes -->

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint"></h5>

    <!-- Tabellerne renderes -->
    <div class="ResultCourseModelWrapper grid_6 clearmarg">
    <!-- Index-tabel tal-->

    <div class="CourseSchemaResultHeader grid_6 clearmarg">
        <div class="FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright">1.1</div>
        <div class="FinalEvaluation_QuestionText grid_5 clearleft">jeg har l&#230;rt meget i dette kursus.</div>
    </div>


<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>1</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 1.8696px solid #990000;"></span>
            </span>&nbsp;0,29%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 1.8696px;">
                <span>1</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>7</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 7.087px solid #990000;"></span>
            </span>&nbsp;2,03%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 7.087px;">
                <span>7</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Hverken eller</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>21</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 19.2609px solid #990000;"></span>
            </span>&nbsp;6,09%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 19.2609px;">
                <span>21</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>88</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 77.5217px solid #990000;"></span>
            </span>&nbsp;25,51%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 77.5217px;">
                <span>88</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>228</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 199.2609px solid #990000;"></span>
            </span>&nbsp;66,09%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 199.2609px;">
                <span>228</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>

    <div class="CourseSchemaResultFooter grid_6 clearmarg ">
        <!-- besvarelses-antal -->
        <span>345 besvarelser</span>
    </div>
</div>

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint"></h5>

    <!-- Tabellerne renderes -->
    <div class="ResultCourseModelWrapper grid_6 clearmarg">
    <!-- Index-tabel tal-->

    <div class="CourseSchemaResultHeader grid_6 clearmarg">
        <div class="FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright">1.2</div>
        <div class="FinalEvaluation_QuestionText grid_5 clearleft">undervisningsaktiviteterne p&#229; kurset stemmer godt overens med kursets l&#230;ringsm&#229;l.
- [Learningobjectives]</div>
    </div>


<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>1</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 1.885px solid #990000;"></span>
            </span>&nbsp;0,29%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 1.885px;">
                <span>1</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>11</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 10.7345px solid #990000;"></span>
            </span>&nbsp;3,24%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 10.7345px;">
                <span>11</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Hverken eller</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>28</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 25.7788px solid #990000;"></span>
            </span>&nbsp;8,26%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 25.7788px;">
                <span>28</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>113</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 101px solid #990000;"></span>
            </span>&nbsp;33,33%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 101px;">
                <span>113</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>186</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 165.6018px solid #990000;"></span>
            </span>&nbsp;54,87%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 165.6018px;">
                <span>186</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>

    <div class="CourseSchemaResultFooter grid_6 clearmarg ">
        <!-- besvarelses-antal -->
        <span>339 besvarelser</span>
    </div>
</div>

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint"></h5>

    <!-- Tabellerne renderes -->
    <div class="ResultCourseModelWrapper grid_6 clearmarg">
    <!-- Index-tabel tal-->

    <div class="CourseSchemaResultHeader grid_6 clearmarg">
        <div class="FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright">1.3</div>
        <div class="FinalEvaluation_QuestionText grid_5 clearleft">undervisningsaktiviteterne motiverer mig til at arbejde med stoffet.</div>
    </div>


<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>11</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 10.7345px solid #990000;"></span>
            </span>&nbsp;3,24%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 10.7345px;">
                <span>11</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>30</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 27.5487px solid #990000;"></span>
            </span>&nbsp;8,85%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 27.5487px;">
                <span>30</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Hverken eller</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>80</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 71.7965px solid #990000;"></span>
            </span>&nbsp;23,60%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 71.7965px;">
                <span>80</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>134</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 119.5841px solid #990000;"></span>
            </span>&nbsp;39,53%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 119.5841px;">
                <span>134</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>84</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 75.3363px solid #990000;"></span>
            </span>&nbsp;24,78%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 75.3363px;">
                <span>84</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>

    <div class="CourseSchemaResultFooter grid_6 clearmarg ">
        <!-- besvarelses-antal -->
        <span>339 besvarelser</span>
    </div>
</div>

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint"></h5>

    <!-- Tabellerne renderes -->
    <div class="ResultCourseModelWrapper grid_6 clearmarg">
    <!-- Index-tabel tal-->

    <div class="CourseSchemaResultHeader grid_6 clearmarg">
        <div class="FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright">1.4</div>
        <div class="FinalEvaluation_QuestionText grid_5 clearleft">jeg i l&#248;bet af kurset har haft mulighed for at f&#229; feedback p&#229;, hvordan jeg fagligt klarer mig p&#229; kurset.</div>
    </div>


<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>5</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 5.451px solid #990000;"></span>
            </span>&nbsp;1,48%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 5.451px;">
                <span>5</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>26</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 24.1454px solid #990000;"></span>
            </span>&nbsp;7,72%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 24.1454px;">
                <span>26</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Hverken eller</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>40</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 36.6083px solid #990000;"></span>
            </span>&nbsp;11,87%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 36.6083px;">
                <span>40</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>136</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 122.0682px solid #990000;"></span>
            </span>&nbsp;40,36%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 122.0682px;">
                <span>136</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>130</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 116.727px solid #990000;"></span>
            </span>&nbsp;38,58%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 116.727px;">
                <span>130</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>

    <div class="CourseSchemaResultFooter grid_6 clearmarg ">
        <!-- besvarelses-antal -->
        <span>337 besvarelser</span>
    </div>
</div>

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint"></h5>

    <!-- Tabellerne renderes -->
    <div class="ResultCourseModelWrapper grid_6 clearmarg">
    <!-- Index-tabel tal-->

    <div class="CourseSchemaResultHeader grid_6 clearmarg">
        <div class="FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright">1.5</div>
        <div class="FinalEvaluation_QuestionText grid_5 clearleft">det generelt har v&#230;ret klart for mig, hvad der forventes af mig i &#248;velser, projektarbejde og lignende.</div>
    </div>


<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>9</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 9.0357px solid #990000;"></span>
            </span>&nbsp;2,68%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 9.0357px;">
                <span>9</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Uenig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>17</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 16.1786px solid #990000;"></span>
            </span>&nbsp;5,06%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 16.1786px;">
                <span>17</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Hverken eller</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>56</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 51px solid #990000;"></span>
            </span>&nbsp;16,67%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 51px;">
                <span>56</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>146</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 131.3571px solid #990000;"></span>
            </span>&nbsp;43,45%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 131.3571px;">
                <span>146</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Helt enig</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>108</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 97.4286px solid #990000;"></span>
            </span>&nbsp;32,14%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 97.4286px;">
                <span>108</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>

    <div class="CourseSchemaResultFooter grid_6 clearmarg ">
        <!-- besvarelses-antal -->
        <span>336 besvarelser</span>
    </div>
</div>

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint">Arbejdsindsats</h5>

    <!-- Tabellerne renderes -->

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint"></h5>

    <!-- Tabellerne renderes -->
    <div class="ResultCourseModelWrapper grid_6 clearmarg">
    <!-- Index-tabel tal-->

    <div class="CourseSchemaResultHeader grid_6 clearmarg">
        <div class="FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright">2.1</div>
        <div class="FinalEvaluation_QuestionText grid_5 clearleft">5 ECTS point er normeret til 9 arbejdstimer/uge i 13-ugersperioden (45 arbejdstimer/uge i treugers-perioden).
Jeg mener, at den tid jeg har brugt p&#229; kurset er</div>
    </div>


<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Meget mindre</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>3</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 3.6866px solid #990000;"></span>
            </span>&nbsp;0,90%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 3.6866px;">
                <span>3</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Noget mindre</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>21</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 19.806px solid #990000;"></span>
            </span>&nbsp;6,27%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 19.806px;">
                <span>21</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Det samme</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>96</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 86.9701px solid #990000;"></span>
            </span>&nbsp;28,66%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 86.9701px;">
                <span>96</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_direct Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Noget mere</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>118</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 106.6716px solid #990000;"></span>
            </span>&nbsp;35,22%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 106.6716px;">
                <span>118</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>
<div class="RowWrapper">

    <div class="context_alternating Row_Container">


        <!-- grad af enighed -->
        <div class="FinalEvaluation_Result_OptionColumn grid_1 clearmarg">Meget mere</div>


        <div class="FinalEvaluation_Result_AnswerPercentageColumn grid_5">

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="Answer_Result_Background">
                <span>97</span>
            </div>

            <!-- den røde bar -->
            <span class="FinalEvaluation_Result_AnswerPercentageSpan">
                <span style="border-left: 87.8657px solid #990000;"></span>
            </span>&nbsp;28,96%

            <!-- Antal for besvarelser af den enkelte type-->
            <div class="FinalEvaluation_Result_AnswerCountColumn" style="width: 87.8657px;">
                <span>97</span>
            </div>
        </div>
        <div style="clear:both"></div>
    </div>

</div>

    <div class="CourseSchemaResultFooter grid_6 clearmarg ">
        <!-- besvarelses-antal -->
        <span>335 besvarelser</span>
    </div>
</div>

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint">Kvalitative kommentarer</h5>

    <!-- Tabellerne renderes -->

</div>


<div id="CourseSchema">
    <!-- Skema A  -->
    <h5 class="noprint"></h5>

    <!-- Tabellerne renderes -->
    <div class="ResultCourseModelWrapper grid_6 clearmarg">
    <!-- Index-tabel tal-->

    <div class="CourseSchemaResultHeader grid_6 clearmarg">
        <div class="FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright">3.1</div>
        <div class="FinalEvaluation_QuestionText grid_5 clearleft">Her kan du skrive generel, konstruktiv feedback om dette kursus
(Her har du mulighed for at give kommentarer om f.eks.
Hvad gik godt? Hvorfor?
Hvilke &#230;ndringer vil du foresl&#229; som kan forbedre kurset?)</div>
    </div>


[Du f&#229;r kun vist kvantitative resultater]
    <div class="CourseSchemaResultFooter grid_6 clearmarg ">
        <!-- besvarelses-antal -->
        <span>0 besvarelser</span>
    </div>
</div>

</div>


</div>



</div>











        <div class="contentModulesContainer">

            <div class="clear"></div>
        </div>




</div>

    <div id="outercontent_0_RightColumn" class="grid_3 rightcolumn">









</div>

    <div class="clear hideInPrint"></div>

    <div class="contentFooter-print hide-desktop hide-mobile">



<div class="contentFooter lineheight12_20">
    <div>


        Opdateret


        &#32;den &#32;8. februar 2022


	</div>



</div>


</div>
</div>
						</div>



			<div id="mobile-container-bottom" class="hide-desktop">
				<div class="container_12"></div>
			</div>
			<div id="mobile-container-bottom-below" class="hide-desktop">
				<div class="container_12"></div>
			</div>




<!--googleoff: all-->
<footer>
    <div class="pagefooter lineheight13_18">
        <div class="container_12">


            <div class="grid_1 minHeight pagefooterlogo" id="footerLogo">
                <a title="Forside" href="https://studieinformation.dtu.dk/">
    <img id="FooterLogo" src="//www.dtu.dk/images/grid/dtulogo_white.png" alt="Studieinformation" /><!-- Image Url: /images/grid/dtulogo_white.png -->
</a>
            </div>
            <div class="grid_5 pagefootercolumn minHeight" id="footerAbout">
                <h2 class="hide-mobile">Uddannelser p&#229; DTU</h2>

<div class="footerintro hide-mobile"><p>DTU er Danmarks st&oslash;rste uddannelsessted for ingeni&oslash;rer. P&aring; DTU kan du blive diplomingeni&oslash;r eller civilingeni&oslash;r, og vi har et stort udbud af uddannelsesretninger og kurser, som du kan v&aelig;lge imellem.</p>
<br>
<p>En ingeni&oslash;ruddannelse fra DTU giver dig en dig en st&aelig;rk teknisk-naturvidenskabelig basis, og gode muligheder for at arbejde som ingeni&oslash;r i mange forskellige typer af job.</p>
<br>
<p><strong><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.dtu.dk/uddannelse" target="_blank">L&aelig;s mere om DTU's uddannelser</a></strong></p></div>

<div class="contactWrapper">

        <div class="footeraddresstitle grid_5 alpha">
            Studieinformation
        </div>

        <div class="footeraddress grid_5 alpha">
            <p><strong>DTU</strong><br>
Anker Engelunds Vej 1<br>
Bygning 101A<br>
2800 Kgs. Lyngby<br>
<br>
45 25 25 25</p>
<p><a href="https://www.dtu.dk/om-dtu/kontakt-og-besoeg/kontakt">Kontakt og bes&oslash;g</a></p>
        </div>

        <div class="accessibilitylink grid_5 alpha">
            <a href="https://www.dtu.dk/om-dtu/tilgaengelighed" target="_blank">Tilg&#230;ngelighed</a>
        </div>

</div>
            </div>
            <div class="grid_3 pagefootercolumn inline-block minHeight" id="footerJob">

            </div>
            <div class="grid_3 pagefootercolumn minHeight" id="footerFollowus">


<h2 class="top-border-mobile">Følg os på</h2>


<div class="socialMediaIcons">
    <a title="Twitter" href="http://twitter.com/#!/DTUtweet" target="_blank">
        <img src="//www.dtu.dk/images/modules/socialmedia/twitter.png" alt="twitter" class="hide-mobile" />
        <img src="//www.dtu.dk/images/modules/socialmedia/twitter-mobile.png" alt="twitter" class="hide-desktop" />
    </a>
    <a title="Facebook" href="http://www.facebook.com/dtudk" target="_blank">
        <img src="//www.dtu.dk/images/modules/socialmedia/facebook.png" alt="facebook" class="hide-mobile" />
        <img src="//www.dtu.dk/images/modules/socialmedia/facebook-mobile.png" alt="facebook" class="hide-desktop" />
    </a>

    <a title="YouTube" href="http://www.youtube.com/DTUbroadcast" target="_blank">
        <img src="//www.dtu.dk/images/modules/socialmedia/youtube.png" alt="YouTube" class="hide-mobile" />
        <img src="//www.dtu.dk/images/modules/socialmedia/youtube-mobile.png" alt="YouTube" class="hide-desktop" />
    </a>
    <a title="LinkedIn" href="http://www.linkedin.com/company/technical-university-of-denmark?trk=hb_tab_compy_id_3933" target="_blank">
        <img src="//www.dtu.dk/images/modules/socialmedia/linkedin.png" alt="LinkedIn" class="hide-mobile" />
        <img src="//www.dtu.dk/images/modules/socialmedia/linkedin-mobile.png" alt="LinkedIn" class="hide-desktop" />
    </a>
    <a title="Instagram" href="https://instagram.com/dtudk/" target="_blank">
        <img src="//www.dtu.dk/images/modules/socialmedia/instagram.png" alt="Instagram" class="hide-mobile" />
        <img src="//www.dtu.dk/images/modules/socialmedia/instagram-mobile.png" alt="Instagram" class="hide-desktop" />
    </a>
</div>

            </div>
            <div class="clear"></div>
        </div>
    </div>



<div >

    <div class="servicemenu" >
        <div class="container_12">
           <div class="grid_3 minHeight">

                <a id="ctl17_ServiceMenuFooter_ServiceMenuLogo" href="https://www.dtu.dk">
                    <span class="servicemenu__link-text">DTU.dk</span>
                </a>

</div>



            <div class="grid_6 minHeight">
                <nav>

                            <div id="ctl17_ServiceMenuFooter_ServiceMenuItems_ServiceMenuItem_0" class="item itemmenu Footer quickdropinstitute" onclick="ToogleServicemenu(this, &#39;Footer&#39;, &#39;Footerc216ff31-cc0b-433d-aa6a-543d609b8aaf&#39;)">
	Institutter &amp; Centre<div class="servicemenuitems">
		<div class="container_12">
			<div>
				<img title="Luk" class="close" onclick="HideServicemenu(this, &#39;Footer&#39;)" src="//www.dtu.dk/images/buttons/close1.png" alt="Luk" /><!-- Image Url: /images/buttons/close1.png -->
			</div><div class="clear"></div><div class="grid_9 col3 divider">
				<h2>Institutter og centre</h2><ul><li><a href="https://www.aqua.dtu.dk/" title="DTU Aqua" target="_blank">DTU Aqua</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/bioengineering/bioengineering_old/forside" title="DTU Bioengineering" target="_blank">DTU Bioengineering</a></li><li><a href="https://www.biosustain.dtu.dk/danish/" title="DTU Biosustain" target="_blank">DTU Biosustain</a></li><li><a href="https://www.byg.dtu.dk/" title="DTU Byg" target="_blank">DTU Byg</a></li><li><a href="https://www.compute.dtu.dk/" title="DTU Compute" target="_blank">DTU Compute</a></li><li><a href="https://www.elektro.dtu.dk/" title="DTU Elektro" target="_blank">DTU Elektro</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/energikonvertering/dtu_energikonvertering_old/forside" title="DTU Energi" target="_blank">DTU Energi</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/engineering_technology/engineering_technology_old/forside" title="DTU Engineering Technology " target="_blank">DTU Engineering Technology </a></li></ul><ul><li><a href="https://www.entrepreneurship.dtu.dk/danish/" title="DTU Entrepreneurship" target="_blank">DTU Entrepreneurship</a></li><li><a href="https://www.fotonik.dtu.dk/" title="DTU Electro" target="_blank">DTU Electro</a></li><li><a href="https://www.fysik.dtu.dk/" title="DTU Fysik" target="_blank">DTU Fysik</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/foedevareinstituttet/dtu_foedevareinstituttet_old/forside" title="DTU Fødevareinstituttet" target="_blank">DTU Fødevareinstituttet</a></li><li><a href="https://www.kemi.dtu.dk/" title="DTU Kemi" target="_blank">DTU Kemi</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/kemiteknik/dtu_kemiteknik_old/forside" title="DTU Kemiteknik" target="_blank">DTU Kemiteknik</a></li><li><a href="https://learnforlife.dtu.dk/" title="DTU  Learn for Life" target="_blank">DTU  Learn for Life</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/management_engineering/dtu_management_engineering_old/forside" title="DTU Management " target="_blank">DTU Management </a></li></ul><ul><li><a href="https://www.mek.dtu.dk/" title="DTU Mekanik" target="_blank">DTU Mekanik</a></li><li><a href="https://www.env.dtu.dk/" title="DTU Miljø" target="_blank">DTU Miljø</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/andre_universitetsenheder/nanolab/dtu_nanolab-old/forside" title="DTU Nanolab" target="_blank">DTU Nanolab</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/andre_universitetsenheder/skylab/skylab_english-old/forside" title="DTU Skylab" target="_blank">DTU Skylab</a></li><li><a href="https://www.space.dtu.dk/" title="DTU Space" target="_blank">DTU Space</a></li><li><a href="https://studieinformation.dtu.dk/sitecore/content/institutter/sundhedsteknologi/dtu_sundhedsteknologi_old/forside" title="DTU Sundhedsteknologi" target="_blank">DTU Sundhedsteknologi</a></li><li><a href="https://windenergy.dtu.dk/" title="DTU Vindenergi" target="_blank">DTU Vindenergi</a></li></ul>
			</div><div class="grid_3">
				<h2>Forskningsgrupper</h2><ul><li><a title="Forskningsgrupper" href="https://www.dtu.dk/forskning/find-forskning/institutter-og-centre#Forskningsgrupper">Forskningsgrupper</a></li></ul>
			</div>
		</div>
	</div>
</div>
                        <div class="item separator"><img src="//www.dtu.dk/images/modules/servicemenu/menu_divider.png" alt="" /></div>
                            <div id="ctl17_ServiceMenuFooter_ServiceMenuItems_ServiceMenuItem_1" class="item itemmenu Footer quickdropshortcuts" onclick="ToogleServicemenu(this, &#39;Footer&#39;, &#39;Footer34b4b505-a037-4fb1-a0e5-90b912879a07&#39;)">
	Genveje<div class="servicemenuitems">
		<div class="container_12">
			<div>
				<img title="Luk" class="close" onclick="HideServicemenu(this, &#39;Footer&#39;)" src="//www.dtu.dk/images/buttons/close1.png" alt="Luk" /><!-- Image Url: /images/buttons/close1.png -->
			</div><div class="clear"></div><div class="grid_3 divider">
				<h2 class="minHeight">Genveje</h2><ul>
    <li><a href="https://www.dtu.dk/soeg?area=samesite&amp;entity=persons">Telefonbog</a></li>
    <li><a href="https://www.dtu.dk/om-dtu/kontakt-og-besoeg/find-vej">Find vej/kort</a></li>
    <li><a href="https://www.dtu.dk/nyheder/presseservice">Presseservice</a></li>
    <li><a href="https://www.dtu.dk/om-dtu/kontakt-og-besoeg/for-leverandoerer">For leverand&oslash;rer (CVR og EAN)</a></li>
</ul>
			</div><div class="grid_3 divider">
				<h2 class="minHeight"></h2><ul>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://kurser.dtu.dk/" target="_blank">Kursusbasen</a> </li>
    <li><a href="https://studieinformation.dtu.dk/">Studieinformation for studerende</a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.inside.dtu.dk" target="_blank">DTU Inside (login)</a> </li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.adgangskursus.dtu.dk/" target="_blank">DTU Adgangskursus</a></li>
</ul>
			</div><div class="grid_3">
				<h2 class="minHeight"></h2><ul>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.dtu.dk/om-dtu/job-og-karriere" target="_blank">Job og Karriere </a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.alumni.dtu.dk/" target="_blank">DTU Alumni</a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.polyteknisk.dk/" target="_blank">Webshop</a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://www.bibliotek.dtu.dk/" target="_blank">DTU Bibliotek</a></li>
    <li><a rel="noopener noreferrer" rel="noopener noreferrer" href="https://orbit.dtu.dk/" target="_blank">DTU Orbit (Forskningsdatabase)</a></li>
</ul>
			</div>
		</div>
	</div>
</div>
                        <div class="item separator"><img src="//www.dtu.dk/images/modules/servicemenu/menu_divider.png" alt="" /></div>
                            <div id="ctl17_ServiceMenuFooter_ServiceMenuItems_ServiceMenuItem_2" class="item">
	<a title="Kontakt" href="https://studieinformation.dtu.dk/service/kontakt">Kontakt</a>
</div>
                        <div class="item separator"><img src="//www.dtu.dk/images/modules/servicemenu/menu_divider.png" alt="" /></div>
                            <div id="ctl17_ServiceMenuFooter_ServiceMenuItems_ServiceMenuItem_3" class="item">



        <a href="javascript:setLanguage('en-GB')">English</a>




</div>

                </nav>
            </div>
            <div class="grid_3 subsitesearch">



<div id="top-search-wrapper" class="top-search-wrapper mobile-menu-dropdown">
    <div id="ctl17_ServiceMenuFooter_SearchBox_SearchboxPanel" class="search">

        <input name="ctl17$ServiceMenuFooter$SearchBox$searchword" type="text" id="ctl17_ServiceMenuFooter_SearchBox_searchword" class="inputtext" />
        <span class="inside-search-btn">
            <input type="submit" name="ctl17$ServiceMenuFooter$SearchBox$searchbutton" value="" onclick="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;ctl17$ServiceMenuFooter$SearchBox$searchbutton&quot;, &quot;&quot;, true, &quot;&quot;, &quot;&quot;, false, false))" id="ctl17_ServiceMenuFooter_SearchBox_searchbutton" title="Søg" class="inputsubmit" />
        </span>

	</div>

    <div id="ctl17_ServiceMenuFooter_SearchBox_SearchButtons" class="hide-desktop search-choice">

        <ul>
            <li data-tabsearch="1">
                <label for="collection1">Studieinformation</label><input value="freeText" name="ctl17$ServiceMenuFooter$SearchBox$" type="radio" id="collection1" /></li>
            <li data-tabsearch="2">
                <label for="collection2">Personer</label><input value="person" name="ctl17$ServiceMenuFooter$SearchBox$" type="radio" id="collection2" /></li>
            <li data-tabsearch="3">
                <label for="collection3">Publikationer</label><input value="publication" name="ctl17$ServiceMenuFooter$SearchBox$" type="radio" id="collection3" /></li>
            <li data-tabsearch="4">
                <label for="collection4">Projekter</label><input value="project" name="ctl17$ServiceMenuFooter$SearchBox$" type="radio" id="collection4" /></li>
        </ul>

	</div>

</div>



</div>
        </div>
    </div>
    <div class="container_12"><div class="grid_12"><div class="subservicemenuFooter subservicemenu"></div><div class="clear"></div></div></div>
</div>

    <div class="printFooter">
        <div class="grid_9">
            https://studieinformation.dtu.dk/service/NoegletalEkstern?hidecontent=true
        </div>
        <div class="grid_3">
            14 SEPTEMBER 2023
        </div>
    </div>
</footer>
<!--googleon: all-->
			<!--googleon: index-->
		</div>



				<!-- FRN: I have no idea what this does -->
				<div class="ytplayer-wrapper hide-desktop" data-cookie-disclaimer-text="Ved at afspille denne video sættes kontekstuelle cookies der vedrører videoen, men som ikke følger din færden på nettet i øvrigt.">
					<div class="ytplayerClose"></div>

					<iframe id="ytframe" width="380" height="320"></iframe>
				</div>


		<div id="search"></div>
		<div id="listSearch"></div>
		<div class="h-page__overlay js-site-overlay"></div>

	<!-- AFR/KOM/WEB/KANT: tag manager container body /23/04/2020 -->
<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-W25B4BH"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
    <script src="//www.dtu.dk/dist/js/behaviors-d07697a7.pkg.js" sri="sha256-OA5B5UTbyTYdO+9SGOCzjSeQa9xo7tZ511Lk1+ZlxkU= sha384-qn3SK2GmhIfCOsbVzaJ8RoJ9mzU9XDy5FDXD7cBoyLpq2TmtcOc3UDrVlJ6YCvmd sha512-V8WKWugowkCyZNTgH1VaINJkehFr7FlNFH/WIOc/KxC+Z6KqMAyPQllVsgngKf5RTJ2Y2vhYYoPYlNyR4jAWjw=="></script>


</body>
</html>



<!--
<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title></title>

</head>
<body>
    <div>

    </div>

</body>
</html>-->
""";

        HtmlEvaluationParser.ParseAll(htmlContent);

        Dictionary<string, string> result = HtmlEvaluationParser.ParseAll(htmlContent);

        // Print the dictionary for demonstration
        foreach (var kvp in result)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        Console.WriteLine(PatternMatcher.RemoveEscapeCharacters("\u00F8"));


    }

    public static Dictionary<string, string> GetQuestionData(string questionIndex, string html)
    {
        Dictionary<string, string> result = new();

        // First, isolate the question section
        string start1 = $"<div class=\"FinalEvaluation_Result_QuestionPositionColumn grid_1 clearright\">{questionIndex}</div>";
        string middle1 = "(.*?)";
        string end1 = "<div class=\"CourseSchemaResultFooter grid_6 clearmarg \">";
        string pattern1 = $"{start1}{middle1}{end1}";
        int groupIndex1 = 1;
        string isolatedHtml = PatternMatcher.Get(pattern1, html, groupIndex1);
        result.Add("Index", questionIndex);

        // Extract the question text
        string start2 = "<div class=\"FinalEvaluation_QuestionText grid_5 clearleft\">";
        string middle2 = "(.*?)";
        string end2 = "</div>";
        string pattern2 = $"{start2}{middle2}{end2}";
        int groupIndex2 = 1;
        string questionText = PatternMatcher.Get(pattern2, isolatedHtml, groupIndex2);
        string questionDecodedText = System.Net.WebUtility.HtmlDecode(questionText);
        result.Add("Q", questionDecodedText);

        // Extract the options
        string start3 = "<div class=\"FinalEvaluation_Result_OptionColumn grid_1 clearmarg\">";
        string middle3 = "(.*?)";
        string end3 = "</div>.*?<span>(\\d+)</span>";
        string pattern3 = $"{start3}{middle3}{end3}";
        Dictionary<string, string> answers = PatternMatcher.GetDict(pattern3, isolatedHtml);
        //string serializedAnswersDct = JsonSerializer.Serialize(answers);
        //result.Add("Answers", serializedAnswersDct);

        foreach (var kvp in answers)
        {
            if (!result.ContainsKey(kvp.Key))
            {
                result.Add(kvp.Key, kvp.Value);
            }
            else
            {
                result[kvp.Key] = kvp.Value;
            }
        }

        // Extract the total responses
        string start4 = "<span>";
        string middle4 = "(\\d+)";
        string end4 = " besvarelser</span>";
        string pattern4 = $"{start4}{middle4}{end4}";
        int groupIndex4 = 1;
        string totalResponses = PatternMatcher.Get(pattern4, html, groupIndex4);
        result.Add("Total Responses", totalResponses);

        // Return statement
        return result;

    }
}


public class PersonClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public PersonClass(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}