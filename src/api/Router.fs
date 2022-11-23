module Router

open Saturn
open Giraffe.Core
open Books.Controller

let api = pipeline {
    plug acceptJson
    set_header "x-pipeline-type" "Api"
}

let apiRouter = router {
    not_found_handler (setStatusCode 404 >=> json "API 404")
    pipe_through api
    forward "/books" booksResources
}

let appRouter' = router {
    not_found_handler (setStatusCode 404 >=> text "API 404")
    forward "" apiRouter
}
