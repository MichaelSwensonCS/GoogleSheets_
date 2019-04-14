OBJDIR  := obj/
BINDIR  := bin/

SFILES   := cpp
OFILES   := o
CC       := g++-8
CFLAGS   := -std=c++17 -static-libstdc++ -pthread -g
OUTPUT   := -o $(BINDIR)server

SOURCES := $(wildcard *.$(SFILES)) $(wildcard */*.$(SFILES))
OBJECTS := $(patsubst %$(SFILES), $(OBJDIR)%$(OFILES), $(SOURCES))

all:	build

build:	$(SOURCES)
		$(CC) $(SOURCES) $(CFLAGS) $(OUTPUT)