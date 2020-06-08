﻿<?xml version="1.0" encoding="utf-8" ?>
@using System.Web.Http
@using $rootnamespace$.Areas.HelpPage.Models
@using leeksnet.AspNet.WebApi.Wadl.Helpers;
@using System.Web.Http.Description;
@model IEnumerable<HelpPageApiModel>
@{
    Layout = null;
    Response.ContentType = "application/xml";
    var hostUrl = Html.ViewContext.HttpContext.Request.Url;
}
<application xmlns:xml="http://www.w3.org/XML/1998/namespace" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" @*xsi:schemalocation="http://wadl.dev.java.net/2009/02 http://www.w3.org/Submission/wadl/wadl.xsd"*@ xmlns="http://wadl.dev.java.net/2009/02">
    <doc title="api" />
    <resources base="@hostUrl.Scheme://@hostUrl.Host">
        @foreach (var api in Model)
            {
            <resource path="@api.ApiDescription.RelativePath">
                <doc title="@api.ApiDescription.RelativePath" /> @* TODO - look at ways to allow specifying doc titles *@
                <method name="@api.ApiDescription.HttpMethod">
                    <request>
                        @foreach (var param in api.UriParameters)
                        {
                            <param name="@param.Name"
                                   style="template"
                                   type="xs:@(param.TypeDescription.ModelType.ToXmlTypeString() ?? "string")"
                                   required="@(param.Annotations.Any(p=>p.Documentation == "Required") ? "true" : "false")" /> @*TODO type mapping needs work!!*@
                        }
                        @foreach (var sampleRequest in api.SampleRequests)
                        {
                            <representation mediaType="@sampleRequest.Key.MediaType">
                                <doc>@sampleRequest.Value</doc>
                            </representation>
                        }
                    </request>
                    @if (api.SampleResponses.Any())
                    {
                        <response status="200">
                            @* TODO can we identify non-200 responses? *@
                            @foreach (var sampleResponse in api.SampleResponses)
                            {
                                <representation mediaType="@sampleResponse.Key.MediaType">
                                    <doc>@sampleResponse.Value</doc>
                                </representation>
                            }
                        </response>
                    }
                </method>
            </resource>
        }
    </resources>
</application>