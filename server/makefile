OBJDIR  := obj/
BINDIR  := bin/

SFILES   := cpp
OFILES   := o
CC       := g++
CFLAGS   := -std=c++11 -DASIO_STANDALONE -I asio-1.12.2/include/ -pthread
OUTPUT   := -o $(BINDIR)server

SOURCES := $(wildcard *.$(SFILES)) $(wildcard */*.$(SFILES))
OBJECTS := $(patsubst %$(SFILES), $(OBJDIR)%$(OFILES), $(SOURCES))

all:	build
build:	$(SOURCES)
		$(CC) $(SOURCES) $(CFLAGS) $(OUTPUT)