cmake_minimum_required(VERSION 3.1)

include(GNUInstallDirs)

project(NativeLibrary VERSION 0.1 DESCRIPTION "Shared native library using .NET Core")

add_custom_target(NativeLibrary
    ALL
    dotnet publish --output ${CMAKE_CURRENT_BINARY_DIR} /p:NativeLib=Shared -r linux-x64
    WORKING_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}
    BYPRODUCTS NativeLibrary.so)

# install(TARGETS ${PROJECT_NAME}
#     LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
#     PUBLIC_HEADER DESTINATION ${CMAKE_INSTALL_INCLUDEDIR})